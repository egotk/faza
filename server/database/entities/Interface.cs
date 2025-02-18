namespace test_Faza.database.entities
{
    public class Interface : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public List<Device> Devices { get; set; } = [];
    }
}
