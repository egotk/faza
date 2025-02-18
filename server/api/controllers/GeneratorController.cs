using Newtonsoft.Json;
using test_Faza.api.dto.requestDTO;
using test_Faza.api.dto.responseDTO;
using test_Faza.api.services.interfaces;
using test_Faza.logger;

namespace test_Faza.api.controllers
{
    internal class GeneratorController
    {
        private readonly IGeneratorService _generatorService;
        private readonly IMyLogger _logger;

        public GeneratorController(IGeneratorService generatorService, IMyLogger logger)
        {
            _generatorService = generatorService;
            _logger = logger;
        }

        public GeneratorResponse HandleTcpRequest(string requestJson)
        {
            BaseRequest? request = JsonConvert.DeserializeObject<BaseRequest>(requestJson);

            if (request == null)
            {
                _logger.LogMessage("Не удалось десериализовать BaseReques", database.entities.MessageType.Error);
                return new GeneratorResponse { Success = false };
            }

            string method = request.Method.ToUpper();

            switch (method)
            {
                case "START":
                    {
                        try
                        {
                            GeneratorResponse response = _generatorService.Start();
                            if (response.Success == true)
                                _logger.LogMessage("Генератор значений регистров запущен", database.entities.MessageType.Success);
                            else
                                _logger.LogMessage("Не удалось запустить генератор значений регистров", database.entities.MessageType.Warning);
                            return response;
                        }
                        catch (Exception ex)
                        {
                            _logger.LogMessage($"Ошибка при запуске генератора: {ex.Message}", database.entities.MessageType.Error);
                            if (ex.InnerException != null)
                                _logger.LogMessage($"Ошибка при запуске генератора: {ex.InnerException.Message}", database.entities.MessageType.Error);
                            return new GeneratorResponse { Success = false };
                        }
                    }
                case "STOP":
                    {
                        try
                        {
                            GeneratorResponse response = _generatorService.Stop();
                            if (response.Success == true)
                                _logger.LogMessage("Генератор значений регистров остановлен", database.entities.MessageType.Success);
                            else
                                _logger.LogMessage("Не удалось остановить генератор значений регистров", database.entities.MessageType.Warning);
                            return response;
                        }
                        catch (Exception ex)
                        {
                            _logger.LogMessage($"Ошибка при остановке генератора: {ex.Message}", database.entities.MessageType.Error);
                            if (ex.InnerException != null)
                                _logger.LogMessage($"Ошибка при остановке генератора: {ex.InnerException.Message}", database.entities.MessageType.Error);
                            return new GeneratorResponse { Success = false };
                        }
                    }
                case "GET_STATUS":
                    {
                        try
                        {
                            GeneratorResponse response = _generatorService.GetStatus();
                            _logger.LogMessage($"Статус генератора: {response.Status}", database.entities.MessageType.Basic);
                            return response;
                        }
                        catch (Exception ex)
                        {
                            _logger.LogMessage($"Ошибка при получении статус генератора: {ex.Message}", database.entities.MessageType.Error);
                            if (ex.InnerException != null)
                                _logger.LogMessage($"Ошибка при получении статуса генератора: {ex.InnerException.Message}", database.entities.MessageType.Error);
                            return new GeneratorResponse { Success = false };
                        }
                    }
                default:
                    {
                        _logger.LogMessage("Неверный метод генератора в запросе", database.entities.MessageType.Error);
                        return new GeneratorResponse { Success = false };
                    }
            }
        }
    }
}

