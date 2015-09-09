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
        T GetById(ObjectId Id);
        Task<T> GetByIdAsync(MongoDB.Bson.ObjectId Id);
        bool Insert(T Document);
        T Update(T Document);
        bool Delete(T Document);
        bool DeleteById(ObjectId Id);
        T DeleteInsert(T Document);
    }
}
