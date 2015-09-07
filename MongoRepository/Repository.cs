using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoRepository
{
    public abstract class Repository<T>
    {
        protected IMongoClient _client;
        protected IMongoDatabase db;

        public string CollectionName { get; set; }
    }
}
