using test_Faza.database.entities;

namespace test_Faza.api.services.interfaces
{
    internal interface IInterfaceService
    {
        Interface? Create(Interface interfaceEntity);

        Interface? Read(int id);

        List<Interface> ReadAllIncluding();

        Interface? Update(Interface interfaceEntity);

        bool Delete(int id);
    }
}
