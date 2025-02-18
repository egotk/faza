using test_faza_client.common.entity;

namespace test_faza_client.api.services.interfaces
{
    internal interface IRegisterService
    {
        Task<bool> Create(Register registerEntity);
        Task<bool> Update(Register registerEntity);
        Task<bool> Delete(Register registerEntity);
    }
}
