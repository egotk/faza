using test_Faza.api.services.interfaces;
using test_Faza.database.entities;
using test_Faza.database.repos.interfaces;

namespace test_Faza.api.services
{
    internal class DeviceService : IDeviceService
    {
        private readonly IDatabaseRepository _databaseRepository;
        private readonly IInterfaceService _interfaceService;

        public DeviceService(IDatabaseRepository databaseRepository, IInterfaceService interfaceService)
        {
            _databaseRepository = databaseRepository;
            _interfaceService = interfaceService;
        }

        public Device? Create(Device deviceEntity)
        {
            try
            {
                bool interfaceExists = _interfaceService.Read(deviceEntity.InterfaceId) != null;
                Device? createdDevice = _databaseRepository.Create(deviceEntity);

                if (interfaceExists && createdDevice != null)
                    return deviceEntity;


                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Device? Read(int id)
        {
            Device? deviceFromDatabase = _databaseRepository.Read<Device>(id);

            if (deviceFromDatabase != null)
                return deviceFromDatabase;

            return null;
        }

        public Device? Update(Device deviceEntity)
        {
            if (_databaseRepository.Update(deviceEntity) != null)
                return deviceEntity;

            return null;
        }

        public bool Delete(int id)
        {
            if (_databaseRepository.Delete<Device>(id))
                return true;

            return false;
        }
    }
}
