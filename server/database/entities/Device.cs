using Newtonsoft.Json;

namespace test_Faza.database.entities
{
    public enum FigureType
    {
        Circle = 0,
        Square = 1,
        Line = 2,
    }

    public class Device : BaseEntity
    {
        public int InterfaceId { get; set; }
        [JsonIgnore]
        public Interface? Interface { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public bool IsEnabled { get; set; } = false;
        public FigureType FigureType { get; set; }
        public int Size { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public required int Color { get; set; }
        public List<Register> Registers { get; set; } = [];
    }
}
