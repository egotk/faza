using test_Faza.database.entities;

namespace test_Faza.api.dto.responseDTO
{
    internal class ValueHistoryResponse : BaseResponse
    {
        public required List<RegisterValue> values;
    }
}
