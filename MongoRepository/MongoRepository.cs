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
        }

        public IEnumerable<T> GetAll<T>()
        {
            IMongoCollection<T> collection = db.GetCollection<T>(this.CollectionName);
            return collection.Find<T>(x => true).ToListAsync<T>().Result;
        }

        public BsonDocument GetById(MongoDB.Bson.ObjectId id)
        {
            var collection = db.GetCollection<BsonDocument>(this.CollectionName);
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("_id", id.ToString());
            return collection.Find<BsonDocument>(filter).FirstOrDefaultAsync().Result;
        }

        public T GetById<T>(ObjectId Id) where T: new()
        {
            var collection = db.GetCollection<T>(this.CollectionName);
            var builder = Builders<T>.Filter;
            var filter = builder.Eq("_id", Id.ToString());
            return new T();
        }

        public void Insert<T>(T Document)
        {
            var collection = db.GetCollection<T>(this.CollectionName);
            collection.InsertOneAsync(Document);
        }

        public T Update<T>(T Document)
        {
            throw new NotImplementedException();
        }

        public void Delete(BsonDocument Document)
        {
            var collection = db.GetCollection<BsonDocument>(this.CollectionName);
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Id", "");
            collection.DeleteOneAsync(filter);
        }

        public void DeleteById(object Id)
        {
            var collection = db.GetCollection<BsonDocument>(this.CollectionName);
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Id", Id.ToString());
            collection.DeleteOneAsync(filter);
        }

        public T DeleteInsert<T>(T Document)
        {
            throw new NotImplementedException();
        }


        public T Delete<T>(T Document)
        {
            throw new NotImplementedException();
        }

        public T DeleteById<T>(object Id)
        {
            throw new NotImplementedException();
        }
    }
}
