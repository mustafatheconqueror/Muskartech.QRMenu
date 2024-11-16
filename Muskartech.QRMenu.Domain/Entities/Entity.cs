using MongoDB.Bson;

namespace Muskartech.QRMenu.Domain.Entities;

public class Entity : IEntity
{
    public ObjectId Id { get; } = ObjectId.GenerateNewId();
    public DateTime InsertedDate { get; } = DateTime.Now.ToUniversalTime();
}