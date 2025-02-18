using test_faza_client.common.entity;

namespace test_faza_client.api.services.interfaces
{
    internal interface IRegisterValueService
    {
        Task<List<RegisterValue>> GetValueHistory(Register registerEntity, DateTime startDate, DateTime endDate);
    }
}
