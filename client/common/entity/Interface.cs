using System.ComponentModel;

namespace test_faza_client.common.entity
{
    internal class Interface : BaseEntity, INameableEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        [Browsable(false)]
        public List<Device> Devices { get; set; } = [];
    }
}
