namespace test_Faza.api.dto.entityDTO
{
    public class RegisterDTO : BaseDTO
    {
        public required int DeviceId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public List<RegisterValueDTO> Values { get; set; } = [];
    }
}
