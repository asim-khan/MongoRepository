using MongoDB.Driver;
using System;
using System.Collections.Generic;
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
                //ConfigurationManager
            }
        }

        public IEnumerable<T> GetAll<T>()
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(MongoDB.Bson.ObjectId Id)
        {
            throw new NotImplementedException();
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
    }
}
