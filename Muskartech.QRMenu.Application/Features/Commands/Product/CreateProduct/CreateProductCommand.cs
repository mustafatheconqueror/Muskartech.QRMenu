using MediatR;
using Muskartech.QRMenu.Application.Wrappers;

namespace Muskartech.QRMenu.Application.Features.Commands.Product.CreateProduct;

public class CreateProductCommand : IRequest<CommandResult>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public string CategoryId { get; set; }
    public string PlaceId { get; set; }
}