using test_Faza.database.entities;

namespace test_Faza.api.services.interfaces
{
    internal interface IDeviceService
    {
        Device? Create(Device deviceEntity);

        Device? Read(int id);

        Device? Update(Device deviceEntity);

        bool Delete(int id);
    }
}
