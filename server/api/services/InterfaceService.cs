using test_Faza.api.services.interfaces;
using test_Faza.database.entities;
using test_Faza.database.repos.interfaces;

namespace test_Faza.api.services
{
    internal class InterfaceService : IInterfaceService
    {
        private readonly IDatabaseRepository _databaseRepository;

        public InterfaceService(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public Interface? Create(Interface interfaceEntity)
        {
            try
            {
                if (_databaseRepository.Create(interfaceEntity) != null)
                {
                    return interfaceEntity;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Interface? Read(int id)
        {
            Interface? interfaceFromDatabase = _databaseRepository.Read<Interface>(id);

            if (interfaceFromDatabase != null)
                return interfaceFromDatabase;

            return null;
        }

        public List<Interface> ReadAllIncluding()
        {
            List<Interface> allInterfaces = _databaseRepository.ReadAllIncluding();

            return allInterfaces;
        }

        public Interface? Update(Interface interfaceEntity)
        {
            try
            {
                _databaseRepository.Update(interfaceEntity);
                return interfaceEntity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            if (_databaseRepository.Delete<Interface>(id))
                return true;

            return false;
        }
    }
}
