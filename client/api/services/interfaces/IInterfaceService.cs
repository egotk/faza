using test_faza_client.common.entity;

namespace test_faza_client.api.service.interfaces
{
    internal interface IInterfaceService
    {
        Task<bool> Create(Interface interfaceEntity);
        Task<bool> Update(Interface interfaceEntity);
        Task<bool> Delete(Interface interfaceEntity);
        Task<List<Interface>> GetAllIncluding();
    }
}
