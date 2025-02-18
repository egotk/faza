using Newtonsoft.Json;
using test_faza_client.api.services.interfaces;
using test_faza_client.common.entity;
using test_faza_client.common.request;
using test_faza_client.common.response;

namespace test_faza_client.api.services
{
    internal class RegisterValueService : IRegisterValueService
    {
        private readonly TcpClientService _tcpClientService;

        public RegisterValueService(TcpClientService tcpClientService)
        {
            _tcpClientService = tcpClientService;
        }

        public async Task<List<RegisterValue>> GetValueHistory(Register registerEntity, DateTime startDate, DateTime endDate)
        {
            ValueHistoryRequest request = new ValueHistoryRequest
            {
                Method = "GET_VALUES_HISTORY",
                TableName = "REGISTER_VALUE",
                RegisterDTO = registerEntity,
                StartDate = startDate,
                EndDate = endDate,
            };

            string? responseJson = await _tcpClientService.SendRequest(request);
            ValueHistoryResponse? response = JsonConvert.DeserializeObject<ValueHistoryResponse>(responseJson);

            if (response != null)
            {
                List<RegisterValue>? values = response.values;
                if (values.Count > 0)
                    return values;
            }

            return [];
        }
    }
}
