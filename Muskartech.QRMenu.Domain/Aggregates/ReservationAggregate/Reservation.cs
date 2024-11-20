using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Muskartech.QRMenu.Domain.Common;
using Muskartech.QRMenu.Domain.Entities;
using Muskartech.QRMenu.Domain.ValueObjects;

namespace Muskartech.QRMenu.Domain.Aggregates.ReservationAggregate;

[BsonIgnoreExtraElements]
public class Reservation : Entity, IAggregateRoot
{
    public Reservation(string restaurantId, string tableId, Customer customer, DateTime reservationStartTime,
        DateTime reservationEndTime)
    {
        RestaurantId = restaurantId ?? throw new ArgumentNullException(nameof(restaurantId));
        TableId = tableId ?? throw new ArgumentNullException(nameof(tableId));
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        ReservationStartTime = reservationStartTime;
        ReservationEndTime = reservationEndTime;
        Status = ReservationStatus.Confirmed;
    }

    [BsonRepresentation(BsonType.ObjectId)]
    public string RestaurantId { get; set; }

    public Customer Customer { get; set; }

    public DateTime ReservationStartTime { get; set; }

    public DateTime ReservationEndTime { get; set; }

    public string TableId { get; set; }

    public ReservationStatus Status { get; private set; }
}


public enum ReservationStatus
{
    Confirmed,
    Cancelled
}