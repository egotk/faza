using test_Faza.api.dto.entityDTO;

namespace test_Faza.api.dto.requestDTO
{
    internal class RegisterValueHistoryRequest : BaseRequest
    {
        public required RegisterDTO RegisterDTO { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
