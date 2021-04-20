using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Proto_API_Yugi.Models.Implementation
{
    public class Card
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string desc { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int level { get; set; }
        public string race { get; set; }
        public string attribute { get; set; }
        public string archetype { get; set; }
        public List<CardSet> card_sets { get; set; }
        public List<CardImage> card_images { get; set; }
        public List<CardPrice> card_prices { get; set; }
        
    }
}