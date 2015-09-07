using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoTestApp.Entities
{
    public class Address
    {
        [BsonElement("coord")]
        public List<double> Coordinates { get; set; }

        [BsonElement("street")]
        public string Street { get; set; }

        [BsonElement("zipcode")]
        public string ZipCode { get; set; }

        [BsonElement("building")]
        public string Building { get; set; }
    }
}
