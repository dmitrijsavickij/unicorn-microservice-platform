using Microsoft.AspNetCore.Mvc;
using Unicorn.Core.Infrastructure.Communication.Common.Operation;
using Unicorn.Core.Infrastructure.HostConfiguration.SDK;
using Unicorn.eShop.Catalog.Features.SoftDeleteItem;
using Unicorn.eShop.Catalog.SDK.DTOs;
using Unicorn.eShop.Catalog.SDK.Services.Http;

namespace Unicorn.eShop.Catalog.Controllers;

public class CatalogServiceController : UnicornHttpService<ICatalogService>, ICatalogService
{
    private readonly ILogger<CatalogServiceController> _logger;

    public CatalogServiceController(ILogger<CatalogServiceController> logger)
    {
        _logger = logger;
    }

    [HttpPost("api/catalog/categories")]
    public Task<OperationResult<CatalogCategory>> CreateCatalogCategoryAsync([FromBody] CatalogCategory catalogCategory)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("api/catalog/items/{id}/soft")]
    public async Task<OperationResult> SoftDeleteItemAsync([FromRoute] Guid id)
    {
        return await SendAsync(new SoftDeleteItemRequest { Id = id });
    }
}
