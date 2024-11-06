using MongoDB.Bson;
using Muskartech.QRMenu.Domain.Common;

namespace Muskartech.QRMenu.Domain.Entities;

public class Entity : IEntity
{
    public ObjectId Id { get; protected set; }
    public DateTime InsertedDate { get; protected set; } = DateTime.Now.ToUniversalTime();
}