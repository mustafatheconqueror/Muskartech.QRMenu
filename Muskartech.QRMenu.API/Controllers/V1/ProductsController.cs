using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Muskartech.QRMenu.Application.Features.Commands.Product.CreateProduct;
using Muskartech.QRMenu.Application.Features.Queries.Product;

namespace Muskartech.QRMenu.API.Controllers.V1;

[Route("api/v1/products")]
[ApiController]
public class ProductsController : BaseController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Conflict)]
    [Authorize(nameof(CreateProduct))]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command, CancellationToken ct)
    {
        var commandResult = await Mediator.Send(command, ct);
        return StatusCode((int)commandResult.HttpStatusCode, commandResult.Result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetProductByIdViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetProductById(string id)
    {
        var query = new GetProductByIdQuery { Id = id };
        return Ok(await Mediator.Send(query));
    }
}