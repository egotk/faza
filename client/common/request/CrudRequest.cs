using test_faza_client.common.entity;

namespace test_faza_client.entities.request
{
    internal class CrudRequest : BaseRequest
    {
        public required BaseEntity Entity { get; set; }
    }
}
