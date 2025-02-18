using test_Faza.api.services.interfaces;
using test_Faza.database.entities;
using test_Faza.database.repos.interfaces;

namespace test_Faza.api.services
{
    internal class RegisterService : IRegisterService
    {
        private readonly IDatabaseRepository _databaseRepository;
        private readonly IDeviceService _deviceService;

        public RegisterService(IDatabaseRepository databaseRepository, IDeviceService deviceService)
        {
            _databaseRepository = databaseRepository;
            _deviceService = deviceService;
        }

        public Register? Create(Register registerEntity)
        {
            if (_databaseRepository.Create<Register>(registerEntity) != null)
                return registerEntity;

            return null;
        }

        public Register? Read(int id)
        {
            Register? registerFromDatabase = _databaseRepository.Read<Register>(id);

            if (registerFromDatabase != null)
                return registerFromDatabase;

            return null;
        }

        public Register? Update(Register registerEntity)
        {
            if (_databaseRepository.Update(registerEntity) != null)
                return registerEntity;

            return null;
        }

        public bool Delete(int id)
        {
            if (_databaseRepository.Delete<Register>(id))
                return true;

            return false;
        }
    }
}

