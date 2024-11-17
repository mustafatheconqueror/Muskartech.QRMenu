using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Muskartech.QRMenu.Application.Wrappers;

namespace Muskartech.QRMenu.Application.Features.Commands.Category.CreateCategory;

public class CreateCategoryCommand : IRequest<CommandResult>
{
    public string? Name { get; set; }
    public string? Description { get; set; }

    public string? PlaceId { get; set; }
    public string? ImageUrl { get; set; }
}