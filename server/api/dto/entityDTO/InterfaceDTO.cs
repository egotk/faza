namespace test_Faza.api.dto.entityDTO
{
    public class InterfaceDTO : BaseDTO
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public List<DeviceDTO> Devices { get; set; } = [];
    }
}
