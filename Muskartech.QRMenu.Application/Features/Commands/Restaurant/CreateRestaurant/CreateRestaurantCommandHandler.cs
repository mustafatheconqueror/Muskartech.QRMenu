using System.Net;
using MediatR;
using Muskartech.QRMenu.Application.Wrappers;
using Muskartech.QRMenu.Domain.Interfaces;

namespace Muskartech.QRMenu.Application.Features.Commands.Restaurant.CreateRestaurant;

public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, CommandResult>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public CreateRestaurantCommandHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository;
    }

    public async Task<CommandResult> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request), "Request cannot be null.");
        }

        var tables = new List<Domain.Aggregates.RestaurantAggregate.Table>();
        foreach (var table in request.Tables)
        {
            var entityTable = new Domain.Aggregates.RestaurantAggregate.Table(table.Name, table.Capacity);
            tables.Add(entityTable);
        }

        var restaurant = new Domain.Aggregates.RestaurantAggregate.Restaurant(request.Name, request!.Location!, tables);

        await _restaurantRepository.InsertAsync(restaurant, cancellationToken);

        return new CommandResult(HttpStatusCode.Created, new { Restaurant = restaurant.Id });
    }
}