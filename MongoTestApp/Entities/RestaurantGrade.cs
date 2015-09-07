using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoTestApp.Entities
{
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
