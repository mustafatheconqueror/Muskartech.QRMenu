using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Muskartech.QRMenu.Application.Features.Commands.Restaurant.CreateRestaurant;
using Muskartech.QRMenu.Application.Features.Queries.Restaurant;

namespace Muskartech.QRMenu.API.Controllers.V1;

[Route("api/v1/restaurants")]
[ApiController]
public class RestaurantController : BaseController
{
    public RestaurantController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Conflict)]
    [Authorize(nameof(CreateRestaurant))]
    public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command, CancellationToken ct)
    {
        var commandResult = await Mediator.Send(command, ct);
        return StatusCode((int)commandResult.HttpStatusCode, commandResult.Result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetRestaurantByIdViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [Authorize(nameof(GetRestaurantById))]
    public async Task<IActionResult> GetRestaurantById(string id, CancellationToken ct)
    {
        var query = new GetRestaurantByIdQuery { Id = id };
        return Ok(await Mediator.Send(query, ct));
    }
}