using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoTestApp.Entities
{
    public class Restaurant
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("restaurant_id")]
        public string RestaurantId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("borough")]
        public string Borough { get; set; }

        [BsonElement("cuisine")]
        public string Cuisine { get; set; }

        [BsonElement("address")]
        public Address Address { get; set; }

        [BsonElement("grades")]
        public List<RestaurantGrade> Grade { get; set; }
    }

    public class RestaurantGrade
    {
        [BsonElement("score")]
        public int? Score { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }

        [BsonElement("grade")]
        public string Grade { get; set; }
    }

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
