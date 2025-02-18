using Microsoft.Extensions.DependencyInjection;
using test_Faza.api.server;
using test_Faza.DI.dependency_container;

IDependencyContainer container = new DependencyContainer();
IServiceProvider provider = container.Configure();

ITcpServer tcpServer = provider.GetRequiredService<ITcpServer>();
await tcpServer.Start();

Console.ReadLine();

