using System.Net;
using MediatR;
using Muskartech.QRMenu.Application.Wrappers;
using Muskartech.QRMenu.Domain.Interfaces;
using Muskartech.QRMenu.Domain.ValueObjects;

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
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request), "Request cannot be null.");
        }

        var contactInfo = new ContactInfo(request.OwnerContactInfo!.Name, request.OwnerContactInfo.Surname,
            request.OwnerContactInfo.Email,
            request.OwnerContactInfo.Phone, request.OwnerContactInfo.Position);

        var place = new Domain.Aggregates.PlaceAggregate.Place(
            name: request.Name,
            location: request.Location,
            ownerContactInfo: contactInfo,
            placeType: (int)request.PlaceType,
            description: request.Description,
            taxNumber: request.TaxNumber,
            logoUrl: request.LogoUrl
        );

        await _placeRepository.InsertAsync(place, cancellationToken);

        return new CommandResult(HttpStatusCode.Created, new { PlaceId = place.Id });
    }
}