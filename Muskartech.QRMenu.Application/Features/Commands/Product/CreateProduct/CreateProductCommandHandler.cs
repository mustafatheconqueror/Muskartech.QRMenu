using System.Net;
using MediatR;
using Muskartech.QRMenu.Application.Features.Commands.Place.CreatePlace;
using Muskartech.QRMenu.Application.Wrappers;
using Muskartech.QRMenu.Domain.Interfaces;
using Muskartech.QRMenu.Domain.ValueObjects;

namespace Muskartech.QRMenu.Application.Features.Commands.Product.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CommandResult>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<CommandResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request), "Request cannot be null.");
        }

        var moneyInfo = new Money("tr-949", request.Price);

        var product = new Domain.Aggregates.ProductAggregate.Product(
            name: request.Name!,
            description: request.Description!,
            price: moneyInfo,
            imageUrl: request.ImageUrl!,
            categoryId: request.CategoryId!,
            placeId: request.PlaceId!
        );


        await _productRepository.InsertAsync(product, cancellationToken);


        return new CommandResult(HttpStatusCode.Created, new { ProductId = product.Id });
    }
}