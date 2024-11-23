using MediatR;

namespace Muskartech.QRMenu.Application.Features.Queries.Restaurant;

public class GetRestaurantByIdQuery : IRequest<GetRestaurantByIdViewModel>
{
    public string Id { get; set; }
}