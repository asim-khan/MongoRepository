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
    public class MongoRepository<T> : IMongoRepository 
    {
        private IMongoClient _client;
        private IMongoDatabase db;

        public MongoRepository(string mongoUrl, string databaseName)
        {
            _client = new MongoClient(mongoUrl);
            db = _client.GetDatabase(databaseName);
        }

        public string MongoUrl
        {
            get
            {
                if (ConfigurationManager.AppSettings["mongourl"] != null)
                    return ConfigurationManager.AppSettings["mongourl"].ToString();
                else
                    return string.Empty;
            }
        }

        public IEnumerable<T> GetAll<T>(string collectionName)
        {
            IMongoCollection<T> collection = db.GetCollection<T>(collectionName);
            return collection.Find<T>(x => true).ToListAsync<T>().Result;
        }

        public BsonDocument GetById(string collectionName, MongoDB.Bson.ObjectId id)
        {
            var collection = db.GetCollection<BsonDocument>(collectionName);
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Id", id.ToString());
            return collection.Find<BsonDocument>(filter).FirstOrDefaultAsync().Result;
        }

        public T Insert<T>(T Document)
        {
            throw new NotImplementedException();
        }

        public T Update<T>(T Document)
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

        public T GetById<T>(ObjectId Id)
        {
            throw new NotImplementedException();
        }

        public T DeleteInsert<T>(T Document)
        {
            throw new NotImplementedException();
        }
    }
}
