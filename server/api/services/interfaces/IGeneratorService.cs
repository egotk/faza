using test_Faza.api.dto.responseDTO;

namespace test_Faza.api.services.interfaces
{
    internal interface IGeneratorService
    {
        GeneratorResponse Start();
        GeneratorResponse Stop();
        GeneratorResponse GetStatus();
    }
}
