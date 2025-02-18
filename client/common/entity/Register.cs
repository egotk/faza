using System.ComponentModel;

namespace test_faza_client.common.entity
{
    internal class Register : BaseEntity, INameableEntity
    {
        public required int DeviceId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        [Browsable(false)]
        public List<RegisterValue> Values { get; set; } = [];
    }
}
