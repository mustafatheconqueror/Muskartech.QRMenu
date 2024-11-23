using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Muskartech.QRMenu.Application.Features.Commands.Reservation.CreateReservation;
using Muskartech.QRMenu.Application.Features.Queries.Reservation;

namespace Muskartech.QRMenu.API.Controllers.V1;

[Route("api/v1/reservations")]
[ApiController]
public class ReservationController : BaseController
{
    public ReservationController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Conflict)]
    [Authorize(nameof(CreateReservation))]
    public async Task<IActionResult> CreateReservation([FromBody] CreateReservationCommand command,
        CancellationToken ct)
    {
        var commandResult = await Mediator.Send(command, ct);
        return StatusCode((int)commandResult.HttpStatusCode, commandResult.Result);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetReservationByIdViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [Authorize(nameof(GetReservationById))]
    public async Task<IActionResult> GetReservationById(string id, CancellationToken ct)
    {
        var query = new GetReservationByIdQuery { Id = id };
        return Ok(await Mediator.Send(query, ct));
    }
}