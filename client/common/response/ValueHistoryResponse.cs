using test_faza_client.common.entity;

namespace test_faza_client.common.response
{
    internal class ValueHistoryResponse : BaseResponse
    {
        public required List<RegisterValue> values;
    }
}
