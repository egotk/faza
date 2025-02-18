using Newtonsoft.Json;

namespace test_Faza.database.entities
{
    public class RegisterValue : BaseEntity
    {
        public int RegisterId { get; set; }
        [JsonIgnore]
        public Register? Register { get; set; }
        public int Value { get; set; }
    }
}
