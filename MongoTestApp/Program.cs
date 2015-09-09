using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoRepository;
using MongoTestApp.Entities;

namespace MongoTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string mongoUrl = "mongodb://127.0.0.1:27017/mongodemo";
            string databaseName = "MongoDemo";

            //IMongoClient _client;
            //IMongoDatabase db;

            //_client = new MongoClient("mongodb://127.0.0.1:27017/mongodemo");
            //db = _client.GetDatabase("MongoDemo");

            //var list = db.GetCollection<Restaurant>("restaurants").Find(x => true).ToListAsync<Restaurant>().Result;

            //foreach (var restaurant in list)
            //{
            //    Console.WriteLine(restaurant.Name);
            //}

            MongoRepository<Restaurant> restaurantRepo = new MongoRepository<Restaurant>(mongoUrl, databaseName, "restaurants");
            //var list = restaurantRepo.GetAll<Restaurant>();

            var t1 = restaurantRepo.GetByIdAsync(new ObjectId("55e69a970e6672a2fb2cc624"));
            var restaurant = restaurantRepo.GetById(new ObjectId("55e69a970e6672a2fb2cc624"));

            Console.ReadLine();
        }
    }
}