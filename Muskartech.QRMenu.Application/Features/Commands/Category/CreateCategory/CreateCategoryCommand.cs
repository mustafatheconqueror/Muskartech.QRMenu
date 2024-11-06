using MediatR;
using Muskartech.QRMenu.Application.Wrappers;

namespace Muskartech.QRMenu.Application.Features.Commands.Category.CreateCategory;

public class CreateCategoryCommand : IRequest<CommandResult>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid CustomerId { get; set; }
}