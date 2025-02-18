using test_Faza.database.entities;

namespace test_Faza.api.services.interfaces
{
    internal interface IRegisterValueService
    {
        List<RegisterValue> GetValuesHistory(Register register, DateTime startDate, DateTime endDate);
    }
}
