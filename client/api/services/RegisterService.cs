using Newtonsoft.Json;
using test_faza_client.api.services.interfaces;
using test_faza_client.common.entity;
using test_faza_client.common.response;
using test_faza_client.entities.request;

namespace test_faza_client.api.services
{
    internal class RegisterService : IRegisterService
    {
        private readonly TcpClientService _tcpClientService;

        public RegisterService(TcpClientService tcpClientService)
        {
            _tcpClientService = tcpClientService;
        }

        public async Task<bool> Create(Register registerEntity)
        {
            CrudRequest request = new CrudRequest
            {
                Method = "POST",
                TableName = "REGISTER",
                Entity = registerEntity,
            };

            bool result = await SendRequestVerifyResponse(request);
            return result;
        }

        public async Task<bool> Update(Register registerEntity)
        {
            CrudRequest request = new CrudRequest
            {
                Method = "PUT",
                TableName = "REGISTER",
                Entity = registerEntity,
            };

            bool result = await SendRequestVerifyResponse(request);
            return result;
        }

        public async Task<bool> Delete(Register registerEntity)
        {
            CrudRequest request = new CrudRequest
            {
                Method = "DELETE",
                TableName = "REGISTER",
                Entity = registerEntity,
            };

            bool result = await SendRequestVerifyResponse(request);
            return result;
        }

        private async Task<bool> SendRequestVerifyResponse(CrudRequest request)
        {
            string? response = await _tcpClientService.SendRequest(request);

            if (response != null)
            {
                BaseResponse? result = JsonConvert.DeserializeObject<BaseResponse>(response);
                if (result != null)
                    return result.Success;
            }

            return false;
        }
    }
}
