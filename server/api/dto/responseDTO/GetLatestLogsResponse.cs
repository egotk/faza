using test_Faza.database.entities;

namespace test_Faza.api.dto.responseDTO
{
    internal class GetLatestLogsResponse : BaseResponse
    {
        public List<Log> Logs { get; set; } = [];
    }
}
