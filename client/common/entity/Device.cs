using System.ComponentModel;

namespace test_faza_client.common.entity
{
    internal enum FigureType
    {
        Circle = 0,
        Square = 1,
        Line = 2,
    }

    internal class Device : BaseEntity, INameableEntity
    {
        public required int InterfaceId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required bool IsEnabled { get; set; }
        public required FigureType FigureType { get; set; }
        public required int Size { get; set; }
        public required int PosX { get; set; }
        public required int PosY { get; set; }
        public required int Color { get; set; }
        [Browsable(false)]
        public List<Register> Registers { get; set; } = [];
    }
}
