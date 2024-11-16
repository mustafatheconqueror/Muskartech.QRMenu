using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Muskartech.QRMenu.Domain.Common;
using Muskartech.QRMenu.Domain.Entities;
using Muskartech.QRMenu.Domain.ValueObjects;

namespace Muskartech.QRMenu.Domain.Aggregates.PlaceAggregate;

[BsonIgnoreExtraElements]
public class Place : Entity, IAggregateRoot
{
    public Place(string name, string location, ContactInfo ownerContactInfo, int placeType, string description,
        string taxNumber, string logoUrl)
    {
        Name = name;
        Location = location;
        OwnerContactInfo = ownerContactInfo;
        PlaceType = placeType;
        Description = description;
        TaxNumber = taxNumber;
        LogoUrl = logoUrl;
    }

    public string Name { get; set; }
    public string Location { get; set; }
    public ContactInfo OwnerContactInfo { get; set; }
    public int PlaceType { get; set; }
    public string Description { get; set; }
    public string TaxNumber { get; set; }
    public string LogoUrl { get; set; }
}