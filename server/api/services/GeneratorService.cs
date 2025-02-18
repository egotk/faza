using test_Faza.api.dto.responseDTO;
using test_Faza.api.services.interfaces;
using test_Faza.generator;

namespace test_Faza.api.services
{
    internal class GeneratorService : IGeneratorService
    {
        private readonly IGenerator _generator;

        public GeneratorService(IGenerator generator)
        {
            _generator = generator;
        }

        public GeneratorResponse Start()
        {
            bool result = _generator.Start();
            bool status = _generator.IsWorking();
            return new GeneratorResponse { Success = result, Status = status };
        }

        public GeneratorResponse Stop()
        {
            bool result = _generator.Stop();
            bool status = _generator.IsWorking();
            return new GeneratorResponse { Success = result, Status = status };
        }

        public GeneratorResponse GetStatus()
        {
            return new GeneratorResponse { Success = true, Status = _generator.IsWorking() };
        }
    }
}
