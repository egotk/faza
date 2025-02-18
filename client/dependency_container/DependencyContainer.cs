using Microsoft.Extensions.DependencyInjection;
using test_faza_client.api;
using test_faza_client.api.service.interfaces;
using test_faza_client.api.services;
using test_faza_client.api.services.interfaces;

namespace test_faza_client.dependencyContainer
{
    internal class DependencyContainer : IDependencyContainer
    {
        public IServiceProvider Configure()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IDeviceService, DeviceService>();
            services.AddSingleton<IGeneratorService, GeneratorService>();
            services.AddSingleton<IInterfaceService, InterfaceService>();
            services.AddSingleton<IRegisterService, RegisterService>();
            services.AddSingleton<IRegisterValueService, RegisterValueService>();
            services.AddSingleton<TcpClientService>();

            IServiceProvider provider = services.BuildServiceProvider();
            return provider;
        }
    }
}
