using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IMongoClient _client;
            IMongoDatabase db;

            _client = new MongoClient("mongodb://127.0.0.1:27017/mongodemo");
            db = _client.GetDatabase("MongoDemo");

            var list = db.GetCollection<Restaurant>("restaurants").Find(x => true).ToListAsync<Restaurant>().Result;

            foreach (var restaurant in list)
            {
                Console.WriteLine(restaurant.Name);
            }
            Console.ReadLine();
       } 
    }

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

    public class RestaurantGrade
    {
        [BsonElement("score")]
        public int? Score { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }

        [BsonElement("grade")]
        public string Grade { get; set; }
    }
}