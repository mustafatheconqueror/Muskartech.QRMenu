using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Muskartech.QRMenu.Domain.Common;
using Muskartech.QRMenu.Domain.Entities;

namespace Muskartech.QRMenu.Domain.Aggregates.CategoryAggregate;

[BsonIgnoreExtraElements]
public class Category : Entity, IAggregateRoot
{
    public Category(string name, string description, string placeId, string? imageUrl)
    {
        Name = name;
        Description = description;
        PlaceId = placeId;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    
    [BsonRepresentation(BsonType.ObjectId)] 
    public string PlaceId { get; set; }

    public string? ImageUrl { get; set; }

   
}