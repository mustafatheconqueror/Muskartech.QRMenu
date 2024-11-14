using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Muskartech.QRMenu.Domain.Aggregates.PlaceAggregate;
using Muskartech.QRMenu.Domain.Interfaces;
using Muskartech.QRMenu.Infrastructure.Settings;

namespace Muskartech.QRMenu.Infrastructure.Persistance.Repository;

public class PlaceRepository : Repository<Place>, IPlaceRepository
{
    public PlaceRepository(MongoClient mongoClient, IOptions<MongoDbSettings> mongoSetting) : base(mongoClient,
        mongoSetting.Value.DatabaseName)
    {
    }
}