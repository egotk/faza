using test_faza_client.common.entity;

namespace test_faza_client.common.response
{
    internal class GetInterfacesResponse : BaseResponse
    {
        public required List<Interface> Interfaces { get; set; }
    }
}
