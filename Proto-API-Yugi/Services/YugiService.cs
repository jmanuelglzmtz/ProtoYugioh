using System.Collections.Generic;
using MongoDB.Driver;
using Proto_API_Yugi.Models.Implementation;
using Proto_API_Yugi.Models.Interfaces;

namespace Proto_API_Yugi.Services
{
    public class YugiService
    {
        private readonly IMongoCollection<Card> _cards;

        public YugiService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _cards = database.GetCollection<Card>("Card");
        }

        public Card Create(Card card)
        {
            _cards.InsertOne(card);
            return card;
        }

        public IList<Card> Read() =>
            _cards.Find(sub => true).ToList();

        public Card Find(string id) =>
            _cards.Find(sub=>sub.id == id).SingleOrDefault();

        public void Update(Card card) =>
            _cards.ReplaceOne(sub => sub.id == card.id, card);

        public void Delete(string id) =>
            _cards.DeleteOne(sub => sub.id == id);
    }
}