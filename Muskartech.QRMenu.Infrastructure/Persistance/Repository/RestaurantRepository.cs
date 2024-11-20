using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Muskartech.QRMenu.Domain.Aggregates.RestaurantAggregate;
using Muskartech.QRMenu.Domain.Interfaces;
using Muskartech.QRMenu.Infrastructure.Settings;

namespace Muskartech.QRMenu.Infrastructure.Persistance.Repository;

public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
{
    public RestaurantRepository(MongoClient mongoClient, IOptions<MongoDbSettings> mongoSetting) : base(mongoClient,
        mongoSetting.Value.DatabaseName)
    {
    }
}