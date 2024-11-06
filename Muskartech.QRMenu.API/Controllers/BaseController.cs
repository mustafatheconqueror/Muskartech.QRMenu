using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Muskartech.QRMenu.API.Controllers;

public abstract class BaseController : ControllerBase
{
    protected BaseController(IMediator mediator)
    {
        Mediator = mediator;
    }

    protected IMediator Mediator { get; }
}
