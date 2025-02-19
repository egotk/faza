using AutoMapper;
using Newtonsoft.Json;
using test_Faza.api.dto.requestDTO;
using test_Faza.api.dto.responseDTO;
using test_Faza.api.services.interfaces;
using test_Faza.database.entities;
using test_Faza.logger;

namespace test_Faza.api.controllers
{
    internal class LogController
    {
        private readonly ILogService _logService;
        private readonly IMapper _mapper;
        private readonly IMyLogger _logger;

        public LogController(ILogService logService, IMapper mapper, IMyLogger logger)
        {
            _logService = logService;
            _mapper = mapper;
            _logger = logger;
        }

        public GetLatestLogsResponse HandleTcpRequest(string requestJson)
        {
            BaseRequest? baseRequest = JsonConvert.DeserializeObject<BaseRequest>(requestJson);

            if (baseRequest == null)
            {
                _logger.LogMessage("Не удалось десериализовать BaseRequest", database.entities.MessageType.Error);
                return new GetLatestLogsResponse { Success = false };
            }

            string method = baseRequest.Method;

            switch (method)
            {
                case "GET_LATEST":
                    {
                        try
                        {
                            List<Log> logs = _logService.GetLatestLogs();
                            _logger.LogMessage("Последние логи успешно получены", database.entities.MessageType.Success);
                            return new GetLatestLogsResponse { Success = true, Logs = logs };
                        }
                        catch (Exception ex)
                        {
                            _logger.LogMessage($"Ошибка при получении последних логов: {ex.Message}", database.entities.MessageType.Error);
                            if (ex.InnerException != null)
                                _logger.LogMessage($"Ошибка при получении последних логов: {ex.InnerException.Message}", database.entities.MessageType.Error);
                            return new GetLatestLogsResponse { Success = false };
                        }
                    }
                default:
                    {
                        _logger.LogMessage("Некорректная операция логов в запросе", database.entities.MessageType.Error);
                        return new GetLatestLogsResponse { Success = false };
                    }
            }
        }
    }
}
