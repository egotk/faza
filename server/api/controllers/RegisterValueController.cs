using AutoMapper;
using Newtonsoft.Json;
using test_Faza.api.dto.entityDTO;
using test_Faza.api.dto.requestDTO;
using test_Faza.api.dto.responseDTO;
using test_Faza.api.services.interfaces;
using test_Faza.database.entities;
using test_Faza.logger;

namespace test_Faza.api.controllers
{
    internal class RegisterValueController
    {
        private readonly IRegisterValueService _registerValueService;
        private readonly IMapper _mapper;
        private readonly IMyLogger _logger;

        public RegisterValueController(IRegisterValueService registerValueService, IMapper mapper, IMyLogger logger)
        {
            _registerValueService = registerValueService;
            _mapper = mapper;
            _logger = logger;
        }

        public BaseResponse HandleTcpRequest(string requestJson)
        {
            RegisterValueHistoryRequest? valueHistoryRequest = JsonConvert.DeserializeObject<RegisterValueHistoryRequest>(requestJson);

            if (valueHistoryRequest == null)
            {
                _logger.LogMessage("Не удалось десериализовать RegisterValueHistoryRequest", database.entities.MessageType.Error);
                return new BaseResponse { Success = false };
            }

            string method = valueHistoryRequest.Method;

            switch (method)
            {
                case "GET_VALUES_HISTORY":
                    {
                        try
                        {
                            Register register = _mapper.Map<Register>(valueHistoryRequest.RegisterDTO);
                            DateTime startDate = valueHistoryRequest.StartDate;
                            DateTime endDate = valueHistoryRequest.EndDate;

                            List<RegisterValueDTO> valuesHistory = _mapper.Map<List<RegisterValueDTO>>(_registerValueService.GetValuesHistory(register, startDate, endDate));

                            if (valuesHistory.Count > 0)
                            {
                                _logger.LogMessage("История значений регистров успешно получена", database.entities.MessageType.Success);
                                return new ValueHistoryResponse { Success = true, values = valuesHistory };
                            }

                            _logger.LogMessage("История значений регистров пуста", database.entities.MessageType.Warning);
                            return new ValueHistoryResponse { Success = false, values = [] };
                        }
                        catch (Exception ex)
                        {
                            _logger.LogMessage($"Ошибка при получении истории значений регистров: {ex.Message}", database.entities.MessageType.Error);
                            if (ex.InnerException != null)
                                _logger.LogMessage($"Ошибка при получении истории значений регистров: {ex.InnerException.Message}", database.entities.MessageType.Error);
                            return new GeneratorResponse { Success = false };
                        }
                    }
                default:
                    {
                        _logger.LogMessage("Неверный метод значений регистров в запросе", database.entities.MessageType.Error);
                        return new BaseResponse { Success = false };
                    }
            }
        }
    }
}
