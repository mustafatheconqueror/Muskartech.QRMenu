using MongoDB.Bson;

namespace Muskartech.QRMenu.Domain.Common;

public interface IEntity
{
    ObjectId Id { get; }
    DateTime InsertedDate { get; }
}