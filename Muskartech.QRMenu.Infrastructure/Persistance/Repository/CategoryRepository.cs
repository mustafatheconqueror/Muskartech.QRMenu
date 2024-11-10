using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Muskartech.QRMenu.Domain.Aggregates.CategoryAggregate;
using Muskartech.QRMenu.Domain.Interfaces;
using Muskartech.QRMenu.Infrastructure.Settings;

namespace Muskartech.QRMenu.Infrastructure.Persistance.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(MongoClient mongoClient, IOptions<MongoDbSettings> mongoSetting) : base(mongoClient,
        mongoSetting.Value.DatabaseName)
    {
    }
}