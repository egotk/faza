using test_Faza.database.entities;
using test_Faza.database.repos.interfaces;
using test_Faza.generator;

namespace test_Faza.timer
{
    internal class Generator : IGenerator
    {
        private readonly int _sleepTime = 1;
        private readonly DateTime _startDate = DateTime.Now;
        private readonly DateTime _endDate = DateTime.Now.AddMonths(1);
        private readonly IDatabaseRepository _databaseRepository;
        private bool _working = false;
        private List<RegisterValue> _registers = [];

        public Generator(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public bool Start()
        {
            if (_working) return false;

            _working = true;
            Random random = new Random();
            TimeSpan timeSpan = _endDate - _startDate;
            List<int> registerIds = _databaseRepository.ReadRegisterIds();

            Task.Run(() =>
            {
                while (_working)
                {
                    TimeSpan newSpan = new TimeSpan(0, random.Next(0, (int)timeSpan.TotalMinutes), 0);
                    RegisterValue registerValue = new()
                    {
                        RegisterId = registerIds[random.Next(registerIds.Count)],
                        Value = random.Next(),
                        Timestamp = _startDate + newSpan,
                    };
                    _registers.Add(registerValue);

                    if (_registers.Count == 200)
                    {
                        _databaseRepository.CreateMultipleValues(_registers);
                        _registers = [];
                    }

                    Thread.Sleep(_sleepTime);
                }
            });

            return true;
        }

        public bool Stop()
        {
            if (!_working) return false;

            _working = false;
            return true;
        }
        public bool IsWorking() => _working;

    }
}
