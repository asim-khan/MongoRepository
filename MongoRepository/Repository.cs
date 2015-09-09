using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoRepository
{
    public abstract class Repository<T>
    {
        protected IMongoClient _client;
        protected IMongoDatabase db;
        protected IMongoCollection<T> collection;

        public string CollectionName { get; set; }

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
    }
}
