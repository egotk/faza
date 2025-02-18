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
    internal class RegisterController
    {
        private readonly IRegisterService _registerService;
        private readonly IMapper _mapper;
        private readonly IMyLogger _logger;

        public RegisterController(IRegisterService registerService, IMapper mapper, IMyLogger logger)
        {
            _registerService = registerService;
            _mapper = mapper;
            _logger = logger;
        }

        public BaseResponse HandleTcpRequest(string requestJson)
        {
            CrudRequest<RegisterDTO>? crudRequest = JsonConvert.DeserializeObject<CrudRequest<RegisterDTO>>(requestJson);

            if (crudRequest == null)
            {
                _logger.LogMessage("Не удалось десериализовать CrudRequest<RegisterDTO>", database.entities.MessageType.Error);
                return new BaseResponse { Success = false };
            }
            string method = crudRequest.Method;

            switch (method)
            {
                case "POST":
                    {
                        try
                        {
                            Register register = _mapper.Map<Register>(crudRequest.Entity);
                            Register? createdRegister = _registerService.Create(register);

                            if (createdRegister != null)
                            {
                                _logger.LogMessage($"Регистр {createdRegister.Name} успешно создан", database.entities.MessageType.Success);
                                return new BaseResponse { Success = true };
                            }

                            _logger.LogMessage($"Не удалось создать регистр {register.Name}", database.entities.MessageType.Warning);
                            return new BaseResponse { Success = false };
                        }
                        catch (Exception ex)
                        {
                            _logger.LogMessage($"Ошибка при создании регистра: {ex.Message}", database.entities.MessageType.Error);
                            if (ex.InnerException != null)
                                _logger.LogMessage($"Ошибка при создании регистра: {ex.InnerException.Message}", database.entities.MessageType.Error);
                            return new GeneratorResponse { Success = false };
                        }
                    }
                case "PUT":
                    {
                        try
                        {
                            Register register = _mapper.Map<Register>(crudRequest.Entity);
                            Register? updatedRegister = _registerService.Update(register);

                            if (updatedRegister != null)
                            {
                                _logger.LogMessage($"Регистр {updatedRegister.Name} успешно обновлён", database.entities.MessageType.Success);
                                return new BaseResponse { Success = true };
                            }

                            _logger.LogMessage($"Не удалось обновить регистр {register.Name}", database.entities.MessageType.Warning);
                            return new BaseResponse { Success = false };
                        }
                        catch (Exception ex)
                        {
                            _logger.LogMessage($"Ошибка при удалении регистра: {ex.Message}", database.entities.MessageType.Error);
                            if (ex.InnerException != null)
                                _logger.LogMessage($"Ошибка при удалении регистра: {ex.InnerException.Message}", database.entities.MessageType.Error);
                            return new GeneratorResponse { Success = false };
                        }
                    }
                case "DELETE":
                    {
                        try
                        {
                            if (crudRequest.Entity.Id == null)
                            {
                                _logger.LogMessage($"ID не передан в запросе DELETE REGISTER", database.entities.MessageType.Warning);
                                return new BaseResponse { Success = false };
                            }

                            int registerId = crudRequest.Entity.Id.Value;
                            bool result = _registerService.Delete(registerId);

                            if (result)
                                _logger.LogMessage($"Регистр {crudRequest.Entity.Name} успешно удалён", database.entities.MessageType.Success);
                            else
                                _logger.LogMessage($"Регистр {crudRequest.Entity.Name} не удалось удалить", database.entities.MessageType.Warning);

                            return new BaseResponse { Success = result };

                        }
                        catch (Exception ex)
                        {
                            _logger.LogMessage($"Ошибка при удалении регистра: {ex.Message}", database.entities.MessageType.Error);
                            if (ex.InnerException != null)
                                _logger.LogMessage($"Ошибка при удалении регистра: {ex.InnerException.Message}", database.entities.MessageType.Error);
                            return new GeneratorResponse { Success = false };
                        }
                    }
                default:
                    {
                        _logger.LogMessage("Неверный метод регистров в запросе", database.entities.MessageType.Error);
                        return new BaseResponse { Success = false };
                    }
            }
        }
    }
}
