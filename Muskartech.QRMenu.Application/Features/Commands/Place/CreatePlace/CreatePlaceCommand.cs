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
    public string LogoUrl { get; set; }
}

public class ContactInfoDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Position { get; set; }
}

public enum PlaceType
{
    [EnumMember(Value = "Restaurant")] Restaurant,
    [EnumMember(Value = "Cafe")] Cafe,
    [EnumMember(Value = "RestaurantAndCafe")]
    RestaurantAndCafe
}