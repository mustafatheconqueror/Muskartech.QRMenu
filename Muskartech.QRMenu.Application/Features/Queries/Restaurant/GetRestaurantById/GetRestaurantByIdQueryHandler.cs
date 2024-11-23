using AutoMapper;
using MediatR;
using Muskartech.QRMenu.Domain.Interfaces;

namespace Muskartech.QRMenu.Application.Features.Queries.Restaurant;

public class GetRestaurantByIdQueryHandler : IRequestHandler<GetRestaurantByIdQuery, GetRestaurantByIdViewModel>
{
    private readonly IRestaurantRepository _restaurantRepository;

    private readonly IMapper _mapper;

    public GetRestaurantByIdQueryHandler(IRestaurantRepository restaurantRepository, IMapper mapper)
    {
        _restaurantRepository = restaurantRepository;
        _mapper = mapper;
    }

    public async Task<GetRestaurantByIdViewModel> Handle(GetRestaurantByIdQuery request,
        CancellationToken cancellationToken)
    {
        var restaurant = await _restaurantRepository.GetByIdAsync(request.Id, cancellationToken);

        return _mapper.Map<GetRestaurantByIdViewModel>(restaurant);
    }
}