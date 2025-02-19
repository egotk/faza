using System.Net;
using System.Text;
using Newtonsoft.Json;
using test_Faza.api.controllers;
using test_Faza.api.dto.entityDTO;
using test_Faza.api.dto.requestDTO;
using test_Faza.api.dto.responseDTO;
using test_Faza.database.entities;
using test_Faza.logger;

namespace test_Faza.api.server.http
{
    internal class HttpServer : IHttpServer
    {
        HttpListener? _listener;
        private readonly InterfaceController _interfaceController;
        private readonly DeviceController _deviceController;
        private readonly RegisterController _registerController;
        private readonly RegisterValueController _registerValueController;
        private readonly GeneratorController _generatorController;
        private readonly LogController _logController;
        private readonly IMyLogger _logger;
        private readonly string _address = "127.0.0.1";
        private readonly int _port = 9999;

        public HttpServer(InterfaceController interfaceController, DeviceController deviceController,
            RegisterController registerController, RegisterValueController registerValueController,
            GeneratorController generatorController, IMyLogger logger, LogController logController)
        {
            _interfaceController = interfaceController;
            _deviceController = deviceController;
            _registerController = registerController;
            _registerValueController = registerValueController;
            _generatorController = generatorController;
            _logger = logger;
            _logController = logController;
        }

        public async Task Start()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add($"http://{_address}:{_port}/");

            try
            {
                _listener.Start();
                _logger.LogMessage($"HTTP Сервер запущен на http://{_address}:{_port}/", database.entities.MessageType.Basic);

                while (true)
                {
                    HttpListenerContext context = await _listener.GetContextAsync();
                    _ = Task.Run(async () => await ProcessRequestAsync(context));
                }
            }
            finally
            {
                _listener.Stop();
            }
        }

        private async Task ProcessRequestAsync(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            try
            {
                using (StreamReader reader = new StreamReader(request.InputStream, request.ContentEncoding))
                using (StreamWriter writer = new StreamWriter(response.OutputStream, request.ContentEncoding))
                {
                    string? requestJson = request.QueryString["json"];

                    // поддержка только GET реквестов, где в строке передаются нужные данные
                    if (requestJson == null)
                    {
                        _logger.LogMessage("В запросе не переданы аргументы(json)", MessageType.Warning);
                        return;
                    }

                    BaseRequest? baseRequest = JsonConvert.DeserializeObject<BaseRequest>(requestJson);

                    if (baseRequest == null)
                    {
                        _logger.LogMessage("Ошибка при десериализации BaseRequest", MessageType.Error);
                        return;
                    }

                    string method = baseRequest.Method;
                    string dbTable = baseRequest.TableName.ToUpper();

                    BaseResponse controllerResponse = new BaseResponse { Success = false };

                    switch (dbTable)
                    {
                        case "INTERFACE":
                            controllerResponse = _interfaceController.HandleTcpRequest(requestJson);
                            break;
                        case "DEVICE":
                            controllerResponse = _deviceController.HandleTcpRequest(requestJson);
                            break;
                        case "REGISTER":
                            controllerResponse = _registerController.HandleTcpRequest(requestJson);
                            break;
                        case "REGISTER_VALUE":
                            controllerResponse = _registerValueController.HandleTcpRequest(requestJson);
                            break;
                        case "GENERATOR":
                            controllerResponse = _generatorController.HandleTcpRequest(requestJson);
                            break;
                        case "LOG":
                            controllerResponse = _logController.HandleTcpRequest(requestJson);
                            break;
                        default:
                            _logger.LogMessage($"Неверное имя сущности в запросе", database.entities.MessageType.Warning);
                            break;
                    }

                    string htmlPage = ConvertBaseResponseToHtml(controllerResponse);
                    response.ContentType = "text/html";
                    response.ContentEncoding = Encoding.UTF8;
                    _logger.LogMessage("HTTP запрос успешно обработан", MessageType.Success);
                    await writer.WriteAsync(htmlPage);
                }
            }
            catch (Exception ex)
            {
                _logger.LogMessage($"Ошибка: {ex}", database.entities.MessageType.Error);
                return;
            }
        }

        private string ConvertBaseResponseToHtml(BaseResponse response)
        {
            switch (response)
            {
                case GeneratorResponse generatorResponse:
                    return GenerateGeneratorResponseHtml(generatorResponse);

                case GetInterfacesResponse getInterfacesResponse:
                    return GenerateGetInterfacesResponseHtml(getInterfacesResponse);

                case ValueHistoryResponse valueHistoryResponse:
                    return GenerateValueHistoryResponseHtml(valueHistoryResponse);

                case GetLatestLogsResponse getLatestLogsResponse:
                    return GenerateLatestLogsResponseHtml(getLatestLogsResponse);

                default:
                    return GenerateBaseResponseHtml(response);
            }
        }

        private string GenerateBaseResponseHtml(BaseResponse response)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"""
                <html>
                <head>
                    <meta content="text/html; charset=UTF-8" http-equiv="Content-Type">
                    <title>
                        Ответ
                    </title>
                </head>
                <body>
                    <h1>
                        Операция {(response.Success ? "выполнена успешно" : "не выполнена")}
                    </h1>
                </body>
                </html>
                """);
            return builder.ToString();
        }

        private string GenerateGeneratorResponseHtml(GeneratorResponse response)
        {
            StringBuilder builder = new StringBuilder();
            // если Status != null, то возвращаем состояние
            builder.Append($"""
                <html>
                <head>
                    <meta content="text/html; charset=UTF-8" http-equiv="Content-Type">
                    <title>
                        Ответ
                    </title>
                </head>
                <body>
                    <h1>
                        Операция {(response.Success ? "выполнена успешно" : "не выполнена")}
                    </h1>
                    <h1>
                        {(response.Status == null ? "" : (bool)response.Status ? "Генератор работает" : "Генератор выключен")}
                    </h1>
                </body>
                </html>
                """);
            return builder.ToString();
        }

        private string GenerateGetInterfacesResponseHtml(GetInterfacesResponse response)
        {
            var builder = new StringBuilder();
            builder.Append("""
                <html>
                <head>
                    <meta content="text/html; charset=UTF-8" http-equiv="Content-Type">
                    <style>
                        th, td { border: 1px solid black; padding: 10px; }
                        th { background-color: lightgrey; }
                    </style>
                </head>
                """);

            foreach (var interfaceEntity in response.Interfaces)
            {
                // Таблица интерфейса
                builder.Append($"""
                        <table>
                            <tr><th>ID</th><th>Имя</th><th>Описание</th></tr>
                            <tr>
                                <td>{interfaceEntity.Id}</td>
                                <td>{interfaceEntity.Name}</td>
                                <td>{interfaceEntity.Description}</td>
                            </tr>
                        </table>
                    """);

                // Таблица устройств
                builder.Append("<h3>Девайсы:</h3>");
                builder.Append("""
                    <table>
                        <tr>
                            <th>ID</th><th>Interface ID</th><th>Имя</th><th>Описание</th>
                            <th>Тип фигуры</th><th>Состояние</th>
                        </tr>
                    """);

                foreach (var device in interfaceEntity.Devices)
                {
                    builder.Append($"""
                        <tr>
                            <td>{device.Id}</td>
                            <td>{device.InterfaceId}</td>
                            <td>{device.Name}</td>
                            <td>{device.Description}</td>
                            <td>{device.FigureType}</td>
                            <td>{(device.IsEnabled ? "Включен" : "Выключен")}</td>
                        </tr>
                        """);
                }
                builder.Append("</table>");

                // Таблица регистров
                builder.Append("<h3>Регистры:</h3>");
                builder.Append("""
                    <table>
                        <tr>
                            <th>ID</th><th>Device ID</th>
                            <th>Имя</th><th>Описание</th>
                        </tr>
                    """);

                foreach (var device in interfaceEntity.Devices)
                {
                    foreach (var register in device.Registers)
                    {
                        builder.Append($"""
                            <tr>
                                <td>{register.Id}</td>
                                <td>{device.Id}</td>
                                <td>{register.Name}</td>
                                <td>{register.Description}</td>
                            </tr>
                            """);
                    }
                }
                builder.Append("</table>");
            }

            builder.Append("</body></html>");
            return builder.ToString();
        }

        private string GenerateValueHistoryResponseHtml(ValueHistoryResponse response)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("<html><head><meta content=\"text/html; charset=UTF-8\" http-equiv=\"Content-Type\"><title>История значений регистров</title></head><body>");
            builder.Append("""
                <table>
                    <tr>
                        <th>
                            Значение
                        </th>
                    </tr>
                </table>
                """);

            foreach (RegisterValueDTO value in response.values)
            {
                builder.Append($"""
                    <tr>
                        <td>{value.Value}</td>
                    </tr>
                    """);
            }

            builder.Append("</body></html>");

            return "";
        }

        private string GenerateLatestLogsResponseHtml(GetLatestLogsResponse response)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("""
                <html>
                <head>
                    <meta content="text/html; charset=UTF-8" http-equiv="Content-Type">
                    <style>
                        th, td { border: 1px solid black; padding: 10px; }
                        th { background-color: lightgrey; }
                    </style>
                </head>
                <body>
                    <table>
                        <tr>
                            <th>Время записи</th>
                            <th>Сообщение</th>
                            <th>Тип</th>
                        </tr>
                """);

            foreach (Log logEntity in response.Logs)
            {
                builder.Append($"""
                <tr>
                    <td>{logEntity.Timestamp}</td>
                    <td>{logEntity.Message}</td>
                    <td>{(logEntity.MessageType == MessageType.Success ? "Успех"
                     : (logEntity.MessageType == MessageType.Warning) ? "Предупреждение"
                     : (logEntity.MessageType == MessageType.Error ? "Ошибка"
                     : "Простое сообщение"))}</td>
                </tr>
                """);
            }

            builder.Append("</table></body></html>");

            return builder.ToString();
        }
    }
}
