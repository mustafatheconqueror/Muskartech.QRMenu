using MongoDB.Bson;

namespace Muskartech.QRMenu.Domain.Entities;

public interface IEntity
{
    ObjectId Id { get; }
    DateTime InsertedDate { get; }
}