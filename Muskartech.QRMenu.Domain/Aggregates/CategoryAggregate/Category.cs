using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Muskartech.QRMenu.Domain.Common;
using Muskartech.QRMenu.Domain.Entities;

namespace Muskartech.QRMenu.Domain.Aggregates.CategoryAggregate;

[BsonIgnoreExtraElements]
public class Category : Entity, IAggregateRoot
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    
    [BsonRepresentation(BsonType.ObjectId)] //Todo: Id'lerin Guid, string vs nasıl kaydedildiklerini detaylıca incele
    public string? CustomerId { get; set; }

    public static Category Create(string name, string description, string customerId)
    {
        var category = new Category()
        {
            Id = ObjectId.GenerateNewId(),
            Name = name,
            Description = description,
            CustomerId = customerId,
        };
        
        //Todo: CategoryCreated Eventi çıkabilir.
        return category;
    }
}