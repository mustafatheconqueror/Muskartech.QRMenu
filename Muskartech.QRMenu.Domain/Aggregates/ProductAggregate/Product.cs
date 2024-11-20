using MongoDB.Bson.Serialization.Attributes;
using Muskartech.QRMenu.Domain.Common;
using Muskartech.QRMenu.Domain.Entities;
using Muskartech.QRMenu.Domain.ValueObjects;

namespace Muskartech.QRMenu.Domain.Aggregates.ProductAggregate;

[BsonIgnoreExtraElements]
public class Product : Entity, IAggregateRoot
{
    public Product(string name, string description, Money price, string imageUrl, string categoryId, string placeId)
    {
        Name = name;
        Description = description;
        Price = price;
        ImageUrl = imageUrl;
        CategoryId = categoryId;
        PlaceId = placeId;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public Money Price { get; set; }
    public string ImageUrl { get; set; }
    public string CategoryId { get; set; }
    public string PlaceId { get; set; }
}