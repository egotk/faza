namespace test_faza_client.api.services.interfaces
{
    internal interface IGeneratorService
    {
        Task<bool?> Start();
        Task<bool?> Stop();
        Task<bool?> GetStatus();
    }
}
