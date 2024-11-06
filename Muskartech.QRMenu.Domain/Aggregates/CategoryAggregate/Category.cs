using MongoDB.Bson.Serialization.Attributes;
using Muskartech.QRMenu.Domain.Common;
using Muskartech.QRMenu.Domain.Entities;

namespace Muskartech.QRMenu.Domain.Aggregates.CategoryAggregate;

[BsonIgnoreExtraElements]
public class Category : Entity, IAggregateRoot
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid CustomerId { get; set; }
}