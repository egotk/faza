using Microsoft.Extensions.DependencyInjection;
using test_Faza.api.controllers;
using test_Faza.api.server;
using test_Faza.api.services;
using test_Faza.api.services.interfaces;
using test_Faza.database.config;
using test_Faza.database.repos;
using test_Faza.database.repos.interfaces;
using test_Faza.DI.mapper;
using test_Faza.generator;
using test_Faza.logger;
using test_Faza.timer;

namespace test_Faza.DI.dependency_container
{
    internal class DependencyContainer : IDependencyContainer
    {
        public IServiceProvider Configure()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<ApplicationContext>();
            services.AddScoped<IDatabaseRepository, DatabaseRepository>();
            services.AddScoped<IInterfaceService, InterfaceService>();
            services.AddScoped<IDeviceService, DeviceService>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<IGeneratorService, GeneratorService>();
            services.AddScoped<IRegisterValueService, RegisterValueService>();
            services.AddScoped<InterfaceController>();
            services.AddScoped<DeviceController>();
            services.AddScoped<RegisterController>();
            services.AddScoped<RegisterValueController>();
            services.AddScoped<GeneratorController>();
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddScoped<IGenerator, Generator>();
            services.AddScoped<IMyLogger, MyLogger>();
            services.AddScoped<ITcpServer, TcpServer>();
            IServiceProvider provider = services.BuildServiceProvider();

            return provider;
        }
    }
}
