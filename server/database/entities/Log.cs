namespace test_Faza.database.entities
{
    public enum MessageType
    {
        Basic = 0,
        Success = 1,
        Warning = 2,
        Error = 3,
    }

    public class Log : BaseEntity
    {
        public required string Message { get; set; }
        public MessageType MessageType { get; set; }
    }
}
