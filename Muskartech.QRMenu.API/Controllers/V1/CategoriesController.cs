using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Muskartech.QRMenu.Application.Features.Commands.Category.CreateCategory;

namespace Muskartech.QRMenu.API.Controllers.V1;

[Route("api/v1/categories")]
[ApiController]
public class CategoriesController : BaseController
{
    public CategoriesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Conflict)]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command, CancellationToken ct)
    {
        var commandResult = await Mediator.Send(command, ct);
        return StatusCode((int)commandResult.HttpStatusCode, commandResult.Result);
    }
}