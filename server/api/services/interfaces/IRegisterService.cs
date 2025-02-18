using test_Faza.database.entities;

namespace test_Faza.api.services.interfaces
{
    internal interface IRegisterService
    {
        Register? Create(Register registerEntity);

        Register? Read(int id);

        Register? Update(Register registerEntity);

        bool Delete(int id);
    }
}
