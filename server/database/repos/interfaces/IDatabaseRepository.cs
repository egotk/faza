using test_Faza.database.entities;

namespace test_Faza.database.repos.interfaces
{
    internal interface IDatabaseRepository
    {
        T? Create<T>(T entity) where T : BaseEntity;
        T? Read<T>(int id) where T : BaseEntity;
        T? Update<T>(T entity) where T : BaseEntity;
        bool Delete<T>(int id) where T : BaseEntity;
        List<Interface> ReadAllIncluding();
        List<int> ReadRegisterIds();
        List<RegisterValue> CreateMultipleValues(List<RegisterValue> values);
        List<RegisterValue> GetValuesHistory(Register register, DateTime startDate, DateTime endDate);
    }
}
