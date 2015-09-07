using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoRepository
{
    public abstract class MongoEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string CollectionName { get; set; }
    }
}
