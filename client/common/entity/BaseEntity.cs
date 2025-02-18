using System.ComponentModel;

namespace test_faza_client.common.entity
{
    internal class BaseEntity
    {
        [ReadOnly(true)]
        public int? Id { get; set; }
        [ReadOnly(true)]
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
