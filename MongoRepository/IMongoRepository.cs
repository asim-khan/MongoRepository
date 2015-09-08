using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoRepository
{
    public interface IMongoRepository<T> where T : MongoEntity, new()
    {
        IEnumerable<T> GetAll<T>();
        BsonDocument GetById(ObjectId Id);
        void Insert<T>(T Document);
        T Update<T>(T Document);
        T Delete<T>(T Document);
        T DeleteById<T>(Object Id);
        T DeleteInsert<T>(T Document);
    }
}
