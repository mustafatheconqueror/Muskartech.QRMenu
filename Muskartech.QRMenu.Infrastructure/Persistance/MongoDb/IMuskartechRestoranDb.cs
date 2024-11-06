using MongoDB.Bson;
using MongoDB.Driver;

namespace Muskartech.QRMenu.Infrastructure.Persistance.MongoDb;

public interface IMuskartechRestoranDb
{
    IMongoCollection<T> GetCollection<T>(string collectionName);
    IMongoCollection<T> GetCollection<T>();
    bool IsDbAvailable();
    List<BsonDocument> ListCollections();
    void CreateCollection(string collectionName);
}