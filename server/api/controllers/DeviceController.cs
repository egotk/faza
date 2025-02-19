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
    internal class DeviceController
    {
        private readonly IDeviceService _deviceService;
        private readonly IMapper _mapper;
        private readonly IMyLogger _logger;

        public DeviceController(IDeviceService deviceService, IMapper mapper, IMyLogger logger)
        {
            _deviceService = deviceService;
            _mapper = mapper;
            _logger = logger;
        }

        public BaseResponse HandleTcpRequest(string requestJson)
        {
            CrudRequest<DeviceDTO>? crudRequest = JsonConvert.DeserializeObject<CrudRequest<DeviceDTO>>(requestJson);

            if (crudRequest == null)
            {
                _logger.LogMessage("Не удалось десериализовать CrudRequest<DeviceDTO>", database.entities.MessageType.Error);
                return new BaseResponse { Success = false };
            }
            string method = crudRequest.Method;

            switch (method)
            {
                case "POST":
                    {
                        try
                        {
                            Device device = _mapper.Map<Device>(crudRequest.Entity);
                            Device? createdDevice = _deviceService.Create(device);

                            if (createdDevice != null)
                            {
                                _logger.LogMessage($"Девайс {createdDevice.Name} успешно создан", database.entities.MessageType.Success);
                                return new BaseResponse { Success = true };
                            }

                            _logger.LogMessage($"Не удалось создать девайс {device.Name}", database.entities.MessageType.Warning);
                            return new BaseResponse { Success = false };
                        }
                        catch (Exception ex)
                        {
                            _logger.LogMessage($"Ошибка при создании девайса: {ex.Message}", database.entities.MessageType.Error);
                            if (ex.InnerException != null)
                                _logger.LogMessage($"Ошибка при создании девайса: {ex.InnerException.Message}", database.entities.MessageType.Error);
                            return new BaseResponse { Success = false };
                        }

                    }
                case "PUT":
                    {
                        try
                        {
                            Device device = _mapper.Map<Device>(crudRequest.Entity);
                            Device? updatedDevice = _deviceService.Update(device);

                            if (updatedDevice != null)
                            {
                                _logger.LogMessage($"Девайс {updatedDevice.Name} успешно обновлён", database.entities.MessageType.Success);
                                return new BaseResponse { Success = true };
                            }

                            _logger.LogMessage($"Не удалось обновить девайс {device.Name}", database.entities.MessageType.Warning);
                            return new BaseResponse { Success = false };
                        }
                        catch (Exception ex)
                        {
                            _logger.LogMessage($"Ошибка при обновлении девайса: {ex.Message}", database.entities.MessageType.Error);
                            if (ex.InnerException != null)
                                _logger.LogMessage($"Ошибка при создании девайса: {ex.InnerException.Message}", database.entities.MessageType.Error);
                            return new BaseResponse { Success = false };
                        }
                    }
                case "DELETE":
                    {
                        try
                        {
                            if (crudRequest.Entity.Id == null)
                            {
                                _logger.LogMessage($"ID не передан в запросе DELETE DEVICE", database.entities.MessageType.Warning);
                                return new BaseResponse { Success = false };
                            }

                            int deviceId = crudRequest.Entity.Id.Value;
                            bool result = _deviceService.Delete(deviceId);

                            if (result)
                                _logger.LogMessage($"Девайс {crudRequest.Entity.Name} успешно удалён", database.entities.MessageType.Success);
                            else
                                _logger.LogMessage($"Девайс {crudRequest.Entity.Name} не удалось удалить", database.entities.MessageType.Warning);

                            return new BaseResponse { Success = result };

                        }
                        catch (Exception ex)
                        {
                            _logger.LogMessage($"Ошибка при удалении девайса: {ex.Message}", database.entities.MessageType.Error);
                            if (ex.InnerException != null)
                                _logger.LogMessage($"Ошибка при удалении девайса: {ex.InnerException.Message}", database.entities.MessageType.Error);
                            return new BaseResponse { Success = false };
                        }
                    }
                default:
                    {
                        _logger.LogMessage("Неверный метод девайсов в запросе", database.entities.MessageType.Error);
                        return new BaseResponse { Success = false };
                    }
            }
        }
    }
}
