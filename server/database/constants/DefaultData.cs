using System.Drawing;
using test_Faza.database.entities;

namespace test_Faza.database.constants
{
    internal class DefaultData
    {
        public static readonly Interface[] defaultInterfaces = new Interface[1];

        public static readonly Device[] defaultDevices = new Device[3];

        public static readonly Register[] defaultRegisters = new Register[9];

        public static readonly RegisterValue[] defaultRegisterValues = new RegisterValue[27];

        // сгенерировать значения по умолчанию
        static DefaultData()
        {
            Random random = new Random();
            var figureTypes = Enum.GetValues(typeof(FigureType));

            // interface
            for (int i = 0; i < defaultInterfaces.Length; i++)
            {
                defaultInterfaces[i] = new Interface
                {
                    Id = i + 1,
                    Name = $"Интерфейс {i}",
                    Description = $"Описание интерфейса {i}",
                };
                // device
                for (int d = 0; d < 3; d++)
                {
                    int deviceIndex = i * 3 + d;
                    defaultDevices[deviceIndex] = new Device
                    {
                        Id = deviceIndex + 1,
                        InterfaceId = i + 1,
                        Name = $"Девайс {deviceIndex}",
                        Description = $"Описание девайса {deviceIndex}",
                        FigureType = (FigureType)figureTypes.GetValue(random.Next(figureTypes.Length))!,
                        Size = random.Next(1, 100),
                        PosX = random.Next(1, 10),
                        PosY = random.Next(1, 10),
                        Color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)).ToArgb(),
                    };
                    // register
                    for (int r = 0; r < 3; r++)
                    {
                        int registerIndex = deviceIndex * 3 + r;
                        defaultRegisters[registerIndex] = new Register
                        {
                            Id = registerIndex + 1,
                            DeviceId = deviceIndex + 1,
                            Name = $"Регистр {r}",
                            Description = $"Описание регистра {r}",
                        };
                    }
                }
            }
        }
    }
}
