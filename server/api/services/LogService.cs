using test_Faza.api.services.interfaces;
using test_Faza.database.entities;
using test_Faza.database.repos.interfaces;

namespace test_Faza.api.services
{
    internal class LogService : ILogService
    {
        private readonly IDatabaseRepository _databaseRepository;

        public LogService(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public List<Log> GetLatestLogs()
        {
            return _databaseRepository.GetLatestLogs();
        }
    }
}
