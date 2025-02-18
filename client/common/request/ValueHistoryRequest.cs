using test_faza_client.common.entity;
using test_faza_client.entities.request;

namespace test_faza_client.common.request
{
    internal class ValueHistoryRequest : BaseRequest
    {
        public required Register RegisterDTO { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
    }
}
