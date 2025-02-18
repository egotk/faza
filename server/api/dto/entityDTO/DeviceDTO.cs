using test_Faza.database.entities;

namespace test_Faza.api.dto.entityDTO
{
    public class DeviceDTO : BaseDTO
    {
        public required int InterfaceId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public bool IsEnabled { get; set; } = false;
        public required FigureType FigureType { get; set; }
        public required int Size { get; set; }
        public required int PosX { get; set; }
        public required int PosY { get; set; }
        public required int Color
        {
            get; set;
        }
        public List<RegisterDTO> Registers { get; set; } = [];
    }
}
