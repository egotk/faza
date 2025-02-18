using test_Faza.api.dto.entityDTO;

namespace test_Faza.api.dto.responseDTO
{
    internal class GetInterfacesResponse : BaseResponse
    {
        public List<InterfaceDTO> Interfaces { get; set; } = [];
    }
}
