using MongoDB.Bson;
using MongoDB.Driver;

namespace Muskartech.QRMenu.Infrastructure.Persistance.MongoDb;

public class MuskartechRestoranDb : IMuskartechRestoranDb
{
    private readonly IMongoDatabase _mongo;

    public MuskartechRestoranDb(IMongoDatabase database)
    {
        _mongo = database;
    }

    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        return _mongo.GetCollection<T>(collectionName);
    }


    public IMongoCollection<T> GetCollection<T>()
    {
        return _mongo.GetCollection<T>(typeof(T).Name);
    }

    public bool IsDbAvailable()
    {
        throw new NotImplementedException();
    }

    public List<BsonDocument> ListCollections()
    {
        throw new NotImplementedException();
    }

    public void CreateCollection(string collectionName)
    {
        throw new NotImplementedException();
    }
}