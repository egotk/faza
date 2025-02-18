namespace test_Faza.api.dto.requestDTO
{
    internal class BaseRequest
    {
        public required string Method { get; set; }
        public required string TableName { get; set; }
    }
}
