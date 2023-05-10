using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var aws = new AWSOptions {Region = RegionEndpoint.EUWest1 };

var builder = new ConfigurationBuilder();
builder.AddSystemsManager("/ParameterStoreReload/TestApp", aws, TimeSpan.FromSeconds(1));

var configuration = builder.Build();

var services = new ServiceCollection();

services.AddOptions();

services.AddScoped<Service>();
services.Configure<ServiceOptions>(configuration);

var sp = services.BuildServiceProvider();

while (true)
{
    using var scope = sp.CreateScope();

    var svc = scope.ServiceProvider.GetRequiredService<Service>();

    svc.PrintValue();

    await Task.Delay(TimeSpan.FromMilliseconds(500));
}

public class Service
{
    private readonly IOptionsSnapshot<ServiceOptions> _options;

    public Service(IOptionsSnapshot<ServiceOptions> options)
    {
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }

    public void PrintValue()
    {
        Console.WriteLine($"{Guid.NewGuid():D}: {_options.Value.Value}");
    }
}

public class ServiceOptions
{
    public int Value { get; set; }
}