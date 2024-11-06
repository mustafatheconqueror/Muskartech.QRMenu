using MongoDB.Bson;

namespace Muskartech.QRMenu.Domain.Entities;

public class Entity : IEntity
{
    public ObjectId Id { get; protected set; }
    public DateTime InsertedDate { get; protected set; } = DateTime.Now.ToUniversalTime();
}