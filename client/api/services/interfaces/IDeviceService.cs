using test_faza_client.common.entity;

namespace test_faza_client.api.services.interfaces
{
    internal interface IDeviceService
    {
        Task<bool> Create(Device deviceEntity);
        Task<bool> Update(Device deviceEntity);
        Task<bool> Delete(Device deviceEntity);
    }
}
