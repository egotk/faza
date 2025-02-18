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
    internal class InterfaceController
    {
        private readonly IInterfaceService _interfaceService;
        private readonly IMapper _mapper;
        private readonly IMyLogger _logger;

        public InterfaceController(IInterfaceService interfaceService, IMapper mapper, IMyLogger logger)
        {
            _interfaceService = interfaceService;
            _mapper = mapper;
            _logger = logger;
        }

        public BaseResponse HandleTcpRequest(string requestJson)
        {
            BaseRequest? baseRequest = JsonConvert.DeserializeObject<BaseRequest>(requestJson);

            if (baseRequest == null)
            {
                _logger.LogMessage("Не удалось десериализовать BaseRequest", database.entities.MessageType.Error);
                return new BaseResponse { Success = false };
            }
            string method = baseRequest.Method.ToUpper();

            switch (method)
            {
                case "GET_ALL":
                    {
                        try
                        {
                            List<Interface> allInterfaces = _interfaceService.ReadAllIncluding();
                            if (allInterfaces != null)
                            {
                                _logger.LogMessage("Все девайсы, устройства, регистры успешно получены", database.entities.MessageType.Success);
                                List<InterfaceDTO> interfaceDtos = _mapper.Map<List<InterfaceDTO>>(allInterfaces);
                                return new GetInterfacesResponse { Success = true, Interfaces = interfaceDtos };
                            }
                            _logger.LogMessage("Не удалось получить все девайсы, устройства, регистры", database.entities.MessageType.Warning);
                            return new GetInterfacesResponse { Success = false };
                        }
                        catch (Exception ex)
                        {
                            _logger.LogMessage($"Ошибка при получении всех девайсов, устройств, регистров: {ex.Message}", database.entities.MessageType.Error);
                            if (ex.InnerException != null)
                                _logger.LogMessage($"Ошибка при получении всех девайсов, устройств, регистров: {ex.InnerException.Message}", database.entities.MessageType.Error);
                            return new GeneratorResponse { Success = false };
                        }
                    }
                case "POST":
                    {
                        try
                        {
                            CrudRequest<InterfaceDTO>? request = JsonConvert.DeserializeObject<CrudRequest<InterfaceDTO>>(requestJson);

                            if (request == null)
                            {
                                _logger.LogMessage("Не удалось десериализовать InterfaceDTO", database.entities.MessageType.Error);
                                return new BaseResponse { Success = false };
                            }

                            Interface interfaceEntity = _mapper.Map<Interface>(request.Entity);
                            Interface? createdInterface = _interfaceService.Create(interfaceEntity);

                            if (createdInterface != null)
                            {
                                _logger.LogMessage($"Интерфейс {createdInterface.Name} успешно создан", database.entities.MessageType.Success);
                                return new BaseResponse { Success = true };
                            }

                            _logger.LogMessage($"Не удалось создать интерфейс {interfaceEntity.Name}", database.entities.MessageType.Warning);
                            return new BaseResponse { Success = false };
                        }
                        catch (Exception ex)
                        {
                            _logger.LogMessage($"Ошибка при создании интерфейса: {ex.Message}", database.entities.MessageType.Error);
                            if (ex.InnerException != null)
                                _logger.LogMessage($"Ошибка при создании интерфейса: {ex.InnerException.Message}", database.entities.MessageType.Error);
                            return new GeneratorResponse { Success = false };
                        }
                    }
                case "PUT":
                    {
                        try
                        {
                            CrudRequest<InterfaceDTO>? request = JsonConvert.DeserializeObject<CrudRequest<InterfaceDTO>>(requestJson);

                            if (request == null)
                            {
                                _logger.LogMessage("Не удалось десериализовать InterfaceDTO", database.entities.MessageType.Error);
                                return new BaseResponse { Success = false };
                            }

                            Interface interfaceEntity = _mapper.Map<Interface>(request.Entity);
                            Interface? updatedInterface = _interfaceService.Update(interfaceEntity);

                            if (updatedInterface != null)
                            {
                                _logger.LogMessage($"Интерфейс {updatedInterface.Name} успешно обновлён", database.entities.MessageType.Success);
                                return new BaseResponse { Success = true };
                            }

                            _logger.LogMessage($"Не удалось обновить интерфейс {interfaceEntity.Name}", database.entities.MessageType.Warning);
                            return new BaseResponse { Success = false };
                        }
                        catch (Exception ex)
                        {
                            _logger.LogMessage($"Ошибка при обновлении интерфейса: {ex.Message}", database.entities.MessageType.Error);
                            if (ex.InnerException != null)
                                _logger.LogMessage($"Ошибка при обновлении интерфейса: {ex.InnerException.Message}", database.entities.MessageType.Error);
                            return new GeneratorResponse { Success = false };
                        }
                    }
                case "DELETE":
                    {
                        try
                        {
                            CrudRequest<InterfaceDTO>? request = JsonConvert.DeserializeObject<CrudRequest<InterfaceDTO>>(requestJson);

                            if (request == null || request.Entity.Id == null)
                            {
                                _logger.LogMessage($"ID не передан в запросе DELETE INTERFACE", database.entities.MessageType.Warning);
                                return new BaseResponse { Success = false };
                            }

                            int interfaceId = request.Entity.Id.Value;
                            bool result = _interfaceService.Delete(interfaceId);

                            if (result)
                                _logger.LogMessage($"Интерфейс {request.Entity.Name} успешно удалён", database.entities.MessageType.Success);
                            else
                                _logger.LogMessage($"Интерфейс {request.Entity.Name} не удалось удалить", database.entities.MessageType.Warning);

                            return new BaseResponse { Success = result };
                        }
                        catch (Exception ex)
                        {
                            _logger.LogMessage($"Ошибка при удалении интерфейса: {ex.Message}", database.entities.MessageType.Error);
                            if (ex.InnerException != null)
                                _logger.LogMessage($"Ошибка при удалении интерфейса: {ex.InnerException.Message}", database.entities.MessageType.Error);
                            return new GeneratorResponse { Success = false };
                        }
                    }
                default:
                    {
                        _logger.LogMessage("Неверный метод интерфесов в запросе", database.entities.MessageType.Error);
                        return new BaseResponse { Success = false };
                    }
            }
        }
    }
}