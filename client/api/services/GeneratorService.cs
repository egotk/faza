using Newtonsoft.Json;
using test_faza_client.api.services.interfaces;
using test_faza_client.common.response;
using test_faza_client.entities.request;

namespace test_faza_client.api.services
{
    internal class GeneratorService : IGeneratorService
    {
        private readonly TcpClientService _tcpClientService;

        public GeneratorService(TcpClientService tcpClientService)
        {
            _tcpClientService = tcpClientService;
        }

        public async Task<bool?> Start()
        {
            BaseRequest request = new BaseRequest
            {
                Method = "START",
                TableName = "GENERATOR",
            };

            string? response = await _tcpClientService.SendRequest(request);

            if (response != null)
            {
                GeneratorResponse? result = JsonConvert.DeserializeObject<GeneratorResponse>(response);

                if (result != null)
                {
                    return result.Success;
                }
            }

            return null;
        }

        public async Task<bool?> Stop()
        {
            BaseRequest request = new BaseRequest
            {
                Method = "STOP",
                TableName = "GENERATOR",
            };

            string? response = await _tcpClientService.SendRequest(request);

            if (response != null)
            {
                GeneratorResponse? result = JsonConvert.DeserializeObject<GeneratorResponse>(response);

                if (result != null)
                {
                    return result.Success;
                }
            }

            return null;
        }

        public async Task<bool?> GetStatus()
        {
            BaseRequest request = new BaseRequest
            {
                Method = "GET_STATUS",
                TableName = "GENERATOR",
            };

            string? response = await _tcpClientService.SendRequest(request);

            if (response != null)
            {
                GeneratorResponse? result = JsonConvert.DeserializeObject<GeneratorResponse>(response);

                if (result != null)
                {
                    return result.Status;
                }
            }

            return null;
        }

        private async Task<GeneratorResponse?> SendRequestVerifyResponse(BaseRequest request)
        {
            string? response = await _tcpClientService.SendRequest(request);

            if (response != null)
            {
                GeneratorResponse? result = JsonConvert.DeserializeObject<GeneratorResponse>(response);
                return result;
            }

            return null;
        }
    }
}
