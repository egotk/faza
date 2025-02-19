using Microsoft.Extensions.DependencyInjection;
using test_Faza.api.server.http;
using test_Faza.api.server.tcp;
using test_Faza.DI.dependency_container;

IDependencyContainer container = new DependencyContainer();
IServiceProvider provider = container.Configure();

IHttpServer httpServer = provider.GetRequiredService<IHttpServer>();
ITcpServer tcpServer = provider.GetRequiredService<ITcpServer>();
await RunServers();


Console.ReadLine();

async Task RunServers()
{
    var tcpTask = tcpServer.Start();
    var httpTask = httpServer.Start();

    await Task.WhenAll(tcpTask, httpTask);
}

await RunServers();
Console.ReadLine();