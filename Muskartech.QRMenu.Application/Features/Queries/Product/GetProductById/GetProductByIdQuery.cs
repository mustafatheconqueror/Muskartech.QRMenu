using MediatR;

namespace Muskartech.QRMenu.Application.Features.Queries.Product;

public class GetProductByIdQuery : IRequest<GetProductByIdViewModel>
{
    public string Id { get; set; }
}