using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Muskartech.QRMenu.Domain.Common;
using Muskartech.QRMenu.Domain.Entities;
using Muskartech.QRMenu.Domain.ValueObjects;

namespace Muskartech.QRMenu.Domain.Aggregates.PlaceAggregate;

[BsonIgnoreExtraElements]
public class Place : Entity, IAggregateRoot
{
    public string Name { get; private set; }
    public string Location { get; private set; }
    public string OwnerName { get; private set; }
    public ContactInfo OwnerContactInfo { get; private set; }
    public string PlaceType { get; private set; }

    private Place(Guid id, string name, string location, string ownerName, ContactInfo ownerContactInfo, string placeType)
    {
        Name = name;
        Location = location;
        OwnerName = ownerName;
        OwnerContactInfo = ownerContactInfo;
        PlaceType = placeType;
    }

    public static Place Create(Guid id, string name, string location, string ownerName, ContactInfo ownerContactInfo, string placeType)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");

        if (string.IsNullOrWhiteSpace(location))
            throw new ArgumentException("Location cannot be empty.");

        if (string.IsNullOrWhiteSpace(ownerName))
            throw new ArgumentException("OwnerName cannot be empty.");

        if (ownerContactInfo == null)
            throw new ArgumentException("OwnerContactInfo cannot be null.");

        return new Place(id, name, location, ownerName, ownerContactInfo, placeType);
    }
}