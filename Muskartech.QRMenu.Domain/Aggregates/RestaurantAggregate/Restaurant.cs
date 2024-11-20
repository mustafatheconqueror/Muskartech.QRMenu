using MongoDB.Bson.Serialization.Attributes;
using Muskartech.QRMenu.Domain.Common;
using Muskartech.QRMenu.Domain.Entities;
using Muskartech.QRMenu.Domain.ValueObjects;

namespace Muskartech.QRMenu.Domain.Aggregates.RestaurantAggregate;

[BsonIgnoreExtraElements]
public class Restaurant : Entity, IAggregateRoot
{
    public Restaurant(string name, string location, List<Table> tables)
    {
        Name = name;
        Location = location;
        Tables = tables;
    }

    public string Name { get; set; }
    public string? Location { get; set; }
    public List<Table> Tables { get; set; }
    public ContactInfo? OwnerContactInfo { get; set; }
}