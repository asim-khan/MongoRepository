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
        virtual IEnumerable<T> GetAll<T>();
        virtual T GetById<T>(ObjectId Id);
        virtual T Insert<T>(T Document);
        virtual T Update<T>(T Document);
        virtual T Delete<T>(T Document);
        virtual T DeleteById<T>(Object Id);
    }
}
