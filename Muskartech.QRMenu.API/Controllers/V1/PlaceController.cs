using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Muskartech.QRMenu.Application.Features.Commands.Place.CreatePlace;

namespace Muskartech.QRMenu.API.Controllers.V1;

[Route("api/v1/places")]
[ApiController]
public class PlaceController : BaseController
{
    public PlaceController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Conflict)]
    public async Task<IActionResult> CreatePlace([FromBody] CreatePlaceCommand command, CancellationToken ct)
    {
        var commandResult = await Mediator.Send(command, ct);
        return StatusCode((int)commandResult.HttpStatusCode, commandResult.Result);
    }
}