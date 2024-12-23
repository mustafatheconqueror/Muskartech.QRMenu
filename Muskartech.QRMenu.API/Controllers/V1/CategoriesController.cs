using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Muskartech.QRMenu.Application.Features.Commands.Category.CreateCategory;
using Muskartech.QRMenu.Application.Features.Queries.Category.GetAllCategories;
using Muskartech.QRMenu.Application.Features.Queries.Category.GetAllCategory;
using Muskartech.QRMenu.Application.Features.Queries.Category.GetCategoryById;
using GetCategoryByIdViewModel = Muskartech.QRMenu.Application.Features.Queries.Category.GetCategoryByIdViewModel;

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
    [Authorize(nameof(CreateCategory))]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command, CancellationToken ct)
    {
        var commandResult = await Mediator.Send(command, ct);
        return StatusCode((int)commandResult.HttpStatusCode, commandResult.Result);
    }


    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetCategoryByIdViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetCategoryById(string id, CancellationToken ct)
    {
        var query = new GetCategoryByIdQuery { Id = id };
        return Ok(await Mediator.Send(query, ct));
    }


    [HttpGet("")]
    [ProducesResponseType(typeof(GetCategoryByIdViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetAllCategories(CancellationToken ct)
    {
        var query = new GetAllCategoryQuery();
        return Ok(await Mediator.Send(query, ct));
    }
}