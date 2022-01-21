using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Unicorn.Core.Development.ClientHost.Features.GetHttpServiceConfiguration;
using Unicorn.Core.Development.ClientHost.Features.OneWayTest;
using Unicorn.Core.Development.ServiceHost.SDK;
using Unicorn.Core.Development.ServiceHost.SDK.Grpc.Clients;
using Unicorn.Core.Infrastructure.Communication.Common.Operation;
using Unicorn.Core.Infrastructure.HostConfiguration.SDK;
using Unicorn.Core.Infrastructure.Security.IAM.AuthenticationScope;
using Unicorn.Core.Services.ServiceDiscovery.SDK;
using Unicorn.Core.Services.ServiceDiscovery.SDK.Configurations;
using static Unicorn.Core.Infrastructure.HostConfiguration.SDK.HostConfigurationExtensions;

namespace Unicorn.Core.Development.ServiceHost.Controllers;

public interface IClientHostService
{
}

public class ClientHostController : UnicornBaseController<IClientHostService>, IClientHostService
{
    private readonly ILogger<ClientHostController> _logger;
    private readonly IBus _bus;
    private readonly IMyGrpcServiceClient _myGrpcSvcClient;
    private readonly IServiceDiscoveryService _svcDiscoveryService;
    private readonly IHttpService _developmentServiceHost;
    private readonly IAuthenticationScope _scopeProvider;

    public ClientHostController(
        IServiceDiscoveryService serviceDiscoveryService,
        IMyGrpcServiceClient myGrpcServiceClient,
        IHttpService developmentServiceHost,
        IAuthenticationScope scopeProvider,
        ILogger<ClientHostController> logger,
        IBus bus)
    {
        _myGrpcSvcClient = myGrpcServiceClient;
        _svcDiscoveryService = serviceDiscoveryService;
        _developmentServiceHost = developmentServiceHost;
        _scopeProvider = scopeProvider;
        _logger = logger;
        _bus = bus;
    }

    [HttpGet("GetHttpServiceConfiguration")]
    public async Task<OperationResult<HttpServiceConfiguration>> Get() =>
        await SendAsync(new GetHttpServiceConfigurationRequest { ServiceName = "test" });

    [HttpGet("GetWeatherForecast/{name}")]
    public async Task<HttpServiceConfiguration> GetName(string name)
    {
        await _developmentServiceHost.SendMessageOneWay(5);
        await _developmentServiceHost.SendMessageOneWay2();

        return new HttpServiceConfiguration();
    }

    [HttpPut("UploadFile2")]
    public async Task<string> UploadFileAsync2(int file)
    {
        return "fff";
    }

    [HttpPut("UploadFile")]
    public async Task UploadFileAsync(IFormFile file)
    {
        return;
    }

    [HttpGet("OneWayTest")]
    public async Task GetOneWay(int number) => await SendAsync(new OneWayRequest { MyProperty = number });
}
