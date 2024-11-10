using MongoDB.Driver;
using Muskartech.QRMenu.Domain.Entities;
using Muskartech.QRMenu.Infrastructure.Exceptions;

namespace Muskartech.QRMenu.Infrastructure.Persistance.Repository;

public abstract class Repository<T> where T : Entity
{
    private readonly IMongoDatabase _database;
    private IMongoCollection<T> Collection => _database.GetCollection<T>(typeof(T).Name);

    protected Repository(MongoClient mongoClient, string dbName)
    {
        _database = mongoClient.GetDatabase(dbName);
    }

    public async Task InsertAsync(T entity, CancellationToken cancellationToken)
    {
        try
        {
            await Collection.InsertOneAsync(entity, null, cancellationToken);
        }
        catch (MongoWriteException mongoWriteException)
        {
            var writeErrorCode = mongoWriteException.WriteError.Code;

            if (writeErrorCode == 11000) // Duplicate key error
            {
                throw new IdempotencyException(mongoWriteException.Message, mongoWriteException);
            }

            throw;
        }
        catch (MongoCommandException mongoCommandException)
        {
            var writeErrorCode = mongoCommandException.Code;

            if (writeErrorCode == 112 || writeErrorCode == 11000)
            {
                throw new IdempotencyException(mongoCommandException.Message, mongoCommandException);
            }

            throw;
        }
    }

}