using System.Runtime.Serialization;
using MediatR;
using Muskartech.QRMenu.Application.Wrappers;

namespace Muskartech.QRMenu.Application.Features.Commands.Place.CreatePlace;

public class CreatePlaceCommand : IRequest<CommandResult>
{
    public string Name { get; set; }
    public string Location { get; set; }
    public ContactInfoDto? OwnerContactInfo { get; set; }
    public PlaceType PlaceType { get; set; }
    public string Description { get; set; }
    public string TaxNumber { get; set; }
    public string LogoUrl { get; set; }
}

public class ContactInfoDto
{
    public string Name { get; protected set; }
    public string Surname { get; protected set; }
    public string Email { get; protected set; }
    public string Phone { get; protected set; }
    public string Position { get; protected set; }
}

public enum PlaceType
{
    [EnumMember(Value = "Restaurant")] Restaurant,
    [EnumMember(Value = "Cafe")] Cafe,
    [EnumMember(Value = "RestaurantAndCafe")]
    RestaurantAndCafe
}