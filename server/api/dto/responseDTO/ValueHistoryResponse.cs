using test_Faza.api.dto.entityDTO;

namespace test_Faza.api.dto.responseDTO
{
    internal class ValueHistoryResponse : BaseResponse
    {
        public required List<RegisterValueDTO> values;
    }
}
