using Newtonsoft.Json;
using test_faza_client.api.service.interfaces;
using test_faza_client.common.entity;
using test_faza_client.common.response;
using test_faza_client.entities.request;

namespace test_faza_client.api.services
{
    internal class InterfaceService : IInterfaceService
    {
        private readonly TcpClientService _tcpClientService;

        public InterfaceService(TcpClientService tcpClientService)
        {
            _tcpClientService = tcpClientService;
        }

        public async Task<bool> Create(Interface interfaceEntity)
        {
            CrudRequest request = new CrudRequest
            {
                Method = "POST",
                TableName = "INTERFACE",
                Entity = interfaceEntity,
            };

            bool result = await SendRequestVerifyResponse(request);
            return result;
        }

        public async Task<bool> Update(Interface interfaceEntity)
        {
            CrudRequest request = new CrudRequest
            {
                Method = "PUT",
                TableName = "INTERFACE",
                Entity = interfaceEntity,
            };

            bool result = await SendRequestVerifyResponse(request);
            return result;
        }

        public async Task<bool> Delete(Interface interfaceEntity)
        {
            CrudRequest request = new CrudRequest
            {
                Method = "DELETE",
                TableName = "INTERFACE",
                Entity = interfaceEntity,
            };

            bool result = await SendRequestVerifyResponse(request);
            return result;
        }

        // TODO: объединить с GetAllIncluding
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

        public async Task<List<Interface>> GetAllIncluding()
        {
            BaseRequest request = new BaseRequest
            {
                Method = "GET_ALL",
                TableName = "INTERFACE",
            };
            string? responseJson = await _tcpClientService.SendRequest(request);

            if (responseJson != null)
            {
                GetInterfacesResponse? response = JsonConvert.DeserializeObject<GetInterfacesResponse>(responseJson);
                if (response != null)
                {
                    List<Interface> interfaces = response.Interfaces;

                    if (interfaces.Count != 0)
                        return interfaces;
                }
            }

            return [];
        }


    }
}
