using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Muskartech.QRMenu.Domain.Aggregates.ProductAggregate;
using Muskartech.QRMenu.Domain.Interfaces;
using Muskartech.QRMenu.Infrastructure.Settings;

namespace Muskartech.QRMenu.Infrastructure.Persistance.Repository;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(MongoClient mongoClient, IOptions<MongoDbSettings> mongoSetting) : base(mongoClient,
        mongoSetting.Value.DatabaseName)
    {
    }
}