using test_Faza.database.entities;
using test_Faza.database.repos.interfaces;

namespace test_Faza.logger
{
    internal class MyLogger : IMyLogger
    {
        private readonly IDatabaseRepository _databaseRepository;

        public MyLogger(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public void LogMessage(string message, MessageType messageType)
        {
            Log log = new Log { Message = message, MessageType = messageType };
            _databaseRepository.Create<Log>(log);
        }
    }
}
