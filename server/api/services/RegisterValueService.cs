using test_Faza.api.services.interfaces;
using test_Faza.database.entities;
using test_Faza.database.repos.interfaces;

namespace test_Faza.api.services
{
    internal class RegisterValueService : IRegisterValueService
    {
        private readonly IDatabaseRepository _databaseRepository;

        public RegisterValueService(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public List<RegisterValue> GetValuesHistory(Register register, DateTime startDate, DateTime endDate)
        {
            List<RegisterValue> values = _databaseRepository.GetValuesHistory(register, startDate, endDate);
            return values;
        }

    }
}
