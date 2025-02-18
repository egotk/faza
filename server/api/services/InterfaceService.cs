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
                    Console.WriteLine($"InterfaceService\r\nИнтерфейс {interfaceEntity.Name} добавлен");
                    return interfaceEntity;
                }

                Console.WriteLine("interfaceEntity не был передан в запросе");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"InterfaceService\r\nОшибка при добавлении:{ex.Message}");
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

        // TODO: REFACTOR
        public List<Interface> ReadAllIncluding()
        {
            List<Interface> allInterfaces = _databaseRepository.ReadAllIncluding();

            return allInterfaces;
        }

        // TODO: REFACTOR
        public Interface? Update(Interface interfaceEntity)
        {
            try
            {
                _databaseRepository.Update(interfaceEntity);
                Console.WriteLine($"InterfaceService\r\nИнтерфейс {interfaceEntity.Name} обновлён");
                return interfaceEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"InterfaceService\r\nОшибка при обновлении:{ex.Message}");
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
