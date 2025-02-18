using test_Faza.api.dto.entityDTO;

namespace test_Faza.api.dto.requestDTO
{
    internal class CrudRequest<T> : BaseRequest where T : BaseDTO
    {
        public required T Entity { get; set; }
    }
}
