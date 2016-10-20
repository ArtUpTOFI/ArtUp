using ArtUp.BankMockServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtUp.BankMockServer.Entities;
using ArtUp.BankMockServer.Context;

namespace ArtUp.BankMockServer.Repositories
{
    public class CardRepository : ICardRepository
    {
        private BankContext db;

        public CardRepository(BankContext c)
        {
            db = c;
        }
        public void Create(Card item)
        {
            db.Cards.Add(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Card> Find(Func<Card, bool> predicate)
        {
            return db.Cards.Where(predicate).ToList();
        }

        public Card Get(int id)
        {
            return db.Cards.Find(id);
        }

        public IEnumerable<Card> GetAll()
        {
            return db.Cards;
        }

        public Card GetcardByNumber(string Nubmer)
        {
            return db.Cards.Where(n => n.Number == Nubmer).First();
        }

        public void Update(Card item)
        {
            throw new NotImplementedException();
        }
    }
}
