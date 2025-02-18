namespace test_faza_client.entities.request
{
    internal class BaseRequest
    {
        public required string Method { get; set; }
        public required string TableName { get; set; }
    }
}
