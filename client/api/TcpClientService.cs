using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using test_faza_client.common.constants;
using test_faza_client.entities.request;

namespace test_faza_client.api
{
    internal class TcpClientService
    {
        private readonly string _ip = DefaultData.ip;
        private readonly int _port = DefaultData.port;

        public async Task<string?> SendRequest(BaseRequest request)
        {
            try
            {
                using (TcpClient client = new(_ip, _port))
                using (NetworkStream stream = client.GetStream())
                using (StreamWriter writer = new(stream, Encoding.UTF8) { AutoFlush = true })
                using (StreamReader reader = new(stream, Encoding.UTF8))
                {
                    string requestJson = JsonConvert.SerializeObject(request);
                    await writer.WriteLineAsync(requestJson);
                    string? response = await reader.ReadLineAsync();

                    return response;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
