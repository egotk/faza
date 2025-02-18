using test_Faza.database.entities;

namespace test_Faza.logger
{
    internal interface IMyLogger
    {
        void LogMessage(string message, MessageType messageType);
    }
}
