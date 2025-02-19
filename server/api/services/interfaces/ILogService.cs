using test_Faza.database.entities;

namespace test_Faza.api.services.interfaces
{
    internal interface ILogService
    {
        List<Log> GetLatestLogs();
    }
}
