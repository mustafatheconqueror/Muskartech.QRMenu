using System.Runtime.Serialization;
using MediatR;
using Muskartech.QRMenu.Application.Wrappers;

namespace Muskartech.QRMenu.Application.Features.Commands.Place.CreatePlace;

public class CreatePlaceCommand : IRequest<CommandResult>
{
    public string? Name { get; set; }
    public string? Location { get; set; }
    public string? OwnerName { get; set; }
    public ContactInfo? OwnerContactInfo { get; set; }
    public PlaceType PlaceType { get; set; }

}

public class ContactInfo
{
    public string? Email { get; set; }
    public string? Phone { get; set; }
}


public enum PlaceType
{
    [EnumMember(Value = "Restaurant")]
    Restaurant,
    [EnumMember(Value = "Cafe")]
    Cafe
}
