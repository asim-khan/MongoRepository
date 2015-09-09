using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoRepository
{
    public class MongoRepository<T> : Repository<T>, IMongoRepository<T> where T : MongoEntity, new()
    {
        public MongoRepository(string mongoUrl, string databaseName, string collectionName)
        {
            this._client = new MongoClient(mongoUrl);
            this.db = _client.GetDatabase(databaseName);
            this.CollectionName = collectionName;
            this.collection = db.GetCollection<T>(this.CollectionName);
        }

        public IEnumerable<T> GetAll<T>()
        {
            IMongoCollection<T> collection = db.GetCollection<T>(this.CollectionName);
            return collection.Find<T>(x => true).ToListAsync<T>().Result;
        }

        public T GetById(ObjectId Id)
        {
            return collection.Find(x => x.Id == Id).FirstOrDefaultAsync().Result;
        }

        public async Task<T> GetByIdAsync(MongoDB.Bson.ObjectId Id)
        {
            return await collection.Find(x => x.Id == Id).FirstAsync();
        }

        public bool Insert(T Document)
        {
            var t1 = collection.InsertOneAsync(Document);
            t1.Wait();
            return t1.IsCompleted;
        }

        public T Update(ObjectId Id, BsonDocument Update)
        {
            var filter = new BsonDocument("_id", Id);
            collection.UpdateOneAsync(filter, Update);
            return GetById(Id);
        }

        public bool Delete(T Document)
        {
            var t1 = collection.DeleteOneAsync(x=>x.Id == Document.Id);
            t1.Wait();
            return t1.IsCompleted;
        }

        public bool DeleteById(ObjectId Id)
        {
            var t = collection.DeleteOneAsync(x => x.Id == Id);
            t.Wait();
            return t.IsCompleted;
        }

        public T DeleteInsert(T Document)
        {
            Delete(Document);
            Insert(Document);
            return GetById(Document.Id);
        }
    }
}
