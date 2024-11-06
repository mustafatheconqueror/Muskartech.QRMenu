using MongoDB.Driver;
using Muskartech.QRMenu.Domain.Aggregates.CategoryAggregate;
using Muskartech.QRMenu.Domain.Interfaces;

namespace Muskartech.QRMenu.Infrastructure.Persistance.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(MongoClient mongoClient, string dbName) : base(mongoClient, dbName)
    {
    }
}