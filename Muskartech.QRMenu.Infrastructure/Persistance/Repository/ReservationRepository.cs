using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Muskartech.QRMenu.Domain.Aggregates.ReservationAggregate;
using Muskartech.QRMenu.Domain.Interfaces;
using Muskartech.QRMenu.Infrastructure.Settings;

namespace Muskartech.QRMenu.Infrastructure.Persistance.Repository;

public class ReservationRepository : Repository<Reservation>, IReservationRepository
{
    public ReservationRepository(MongoClient mongoClient, IOptions<MongoDbSettings> mongoSetting) : base(mongoClient,
        mongoSetting.Value.DatabaseName)
    {
    }
}