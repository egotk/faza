using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using test_Faza.api.controllers;
using test_Faza.api.dto.requestDTO;
using test_Faza.api.dto.responseDTO;
using test_Faza.api.server.tcp;
using test_Faza.logger;

namespace test_Faza.api.server
{
    internal class TcpServer : ITcpServer
    {
        private TcpListener? _listener;
        private readonly InterfaceController _interfaceController;
        private readonly DeviceController _deviceController;
        private readonly RegisterController _registerController;
        private readonly RegisterValueController _registerValueController;
        private readonly GeneratorController _generatorController;
        private readonly IMyLogger _logger;
        private readonly int _timeout = 10000;
        private readonly int _port = 8888;
        private readonly IPAddress _address = IPAddress.Parse("127.0.0.1");



        public TcpServer(InterfaceController interfaceController, DeviceController deviceController, RegisterController registerController, RegisterValueController registerValueController, GeneratorController generatorController, IMyLogger logger)
        {
            _interfaceController = interfaceController;
            _deviceController = deviceController;
            _registerController = registerController;
            _registerValueController = registerValueController;
            _generatorController = generatorController;
            _logger = logger;
        }

        public async Task Start()
        {
            _listener = new TcpListener(_address, _port);

            try
            {
                _listener.Start();
                _logger.LogMessage($"TCP Сервер запущен на порте={_port} IP={_address}", database.entities.MessageType.Basic);

                while (true)
                {
                    TcpClient client = await _listener.AcceptTcpClientAsync();
                    _ = Task.Run(async () => await ProcessClientAsync(client));
                }
            }
            finally
            {
                _listener.Stop();
                _logger.LogMessage($"TCP Сервер на порте={_port} IP={_address} остановлен", database.entities.MessageType.Basic);
            }

        }

        private async Task ProcessClientAsync(TcpClient client)
        {
            string? clientEndpoint = client.Client.RemoteEndPoint!.ToString();
            try
            {
                using (client)
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream, encoding: Encoding.UTF8))
                using (StreamWriter writer = new StreamWriter(stream, encoding: Encoding.UTF8))
                {

                    string? requestJson = await reader.ReadLineAsync();

                    if (requestJson == null)
                    {
                        _logger.LogMessage("Пустое сообщение на сервер", database.entities.MessageType.Warning);
                        return;
                    }

                    var processRequest = Task.Run(() => ProcessRequest(requestJson));

                    // таймаут операции
                    var timer = Task.Delay(_timeout);
                    if (await Task.WhenAny(processRequest, timer) != processRequest)
                        throw new TimeoutException("Превышено время ожидания");

                    BaseResponse response = await processRequest;
                    var responseJson = JsonConvert.SerializeObject(response);
                    _logger.LogMessage($"Запрос {responseJson}", database.entities.MessageType.Basic);
                    await writer.WriteAsync(responseJson);
                    await writer.FlushAsync();
                }
            }
            catch (TimeoutException ex)
            {
                _logger.LogMessage($"{ex.Message}", database.entities.MessageType.Error);
            }
            finally
            {
                _logger.LogMessage($"Клиент {clientEndpoint} отключился", database.entities.MessageType.Basic);
            }
        }

        private BaseResponse ProcessRequest(string requestJson)
        {
            try
            {
                _logger.LogMessage($"Запрос {requestJson}", database.entities.MessageType.Basic);
                BaseRequest? request = JsonConvert.DeserializeObject<BaseRequest>(requestJson);

                if (request == null)
                {
                    _logger.LogMessage("Ошибка при десериализации сообщения", database.entities.MessageType.Error);
                    return new BaseResponse { Success = false };
                }

                string method = request.Method.ToUpper();
                string dbTable = request.TableName.ToUpper();

                switch (dbTable)
                {
                    case "INTERFACE":
                        return _interfaceController.HandleTcpRequest(requestJson);
                    case "DEVICE":
                        return _deviceController.HandleTcpRequest(requestJson);
                    case "REGISTER":
                        return _registerController.HandleTcpRequest(requestJson);
                    case "REGISTER_VALUE":
                        return _registerValueController.HandleTcpRequest(requestJson);
                    case "GENERATOR":
                        return _generatorController.HandleTcpRequest(requestJson);
                    default:
                        {
                            _logger.LogMessage($"Неверное имя сущности в запросе", database.entities.MessageType.Warning);
                            return new BaseResponse { Success = false };
                        }
                }
            }
            catch (Exception ex)
            {
                _logger.LogMessage($"Ошибка при обработке запроса: {ex.Message}", database.entities.MessageType.Error);
                return new BaseResponse { Success = false };
            }
        }
    }
}
