using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoRepository
{
    public interface IMongoRepository
    {
        IEnumerable<T> GetAll<T>(string collectionName);
        BsonDocument GetById(string collectionName, ObjectId Id);
        T Insert<T>(T Document);
        T Update<T>(T Document);
        T Delete<T>(T Document);
        T DeleteById<T>(Object Id);
        T DeleteInsert<T>(T Document);
    }
}
