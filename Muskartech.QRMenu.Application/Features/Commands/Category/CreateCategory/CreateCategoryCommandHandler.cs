using System.Net;
using MediatR;
using Muskartech.QRMenu.Application.Wrappers;

namespace Muskartech.QRMenu.Application.Features.Commands.Category.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CommandResult>
{
    public CreateCategoryCommandHandler()
    {
    }

    public async Task<CommandResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        return new CommandResult(HttpStatusCode.NoContent);
    }
}