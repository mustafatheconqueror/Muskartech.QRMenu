using System.Net;
using MediatR;
using Muskartech.QRMenu.Application.Wrappers;
using Muskartech.QRMenu.Domain.Interfaces;

namespace Muskartech.QRMenu.Application.Features.Commands.Place.CreatePlace;

public class CreatePlaceCommandHandler : IRequestHandler<CreatePlaceCommand, CommandResult>
{
    private readonly IPlaceRepository _placeRepository;

    public CreatePlaceCommandHandler(IPlaceRepository placeRepository)
    {
        _placeRepository = placeRepository;
    }

    public async Task<CommandResult> Handle(CreatePlaceCommand request, CancellationToken cancellationToken)
    {
        //Todo: bu kontrollei bir validatöre aktar.
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request), "Request cannot be null.");
        }
        
        var contactInfo = Domain.ValueObjects.ContactInfo.Create(request.OwnerContactInfo!.Email!, request.OwnerContactInfo.Phone!);
        
        var placeType = request.PlaceType switch
        {
            PlaceType.Restaurant => "Restaurant",
            PlaceType.Cafe => "Cafe",
            _ => throw new ArgumentException($"Invalid PlaceType: {request.PlaceType}")
        };
        
        
        var place =  Domain.Aggregates.PlaceAggregate.Place.Create(
            id: Guid.NewGuid(),
            name: request.Name!,
            location: request.Location!,
            ownerName: request.OwnerName!,
            ownerContactInfo: contactInfo,
            placeType: placeType
        );
        

        await _placeRepository.InsertAsync(place, cancellationToken);


        return new CommandResult(HttpStatusCode.Created, new { PlaceId = place.Id });
    }
}