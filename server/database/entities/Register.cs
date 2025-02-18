using Newtonsoft.Json;

namespace test_Faza.database.entities
{
    public class Register : BaseEntity
    {
        public int DeviceId { get; set; }
        [JsonIgnore]
        public Device? Device { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public List<RegisterValue> Values { get; set; } = [];
    }
}
