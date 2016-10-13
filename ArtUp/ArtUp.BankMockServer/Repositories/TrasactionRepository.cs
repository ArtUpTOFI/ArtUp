using ArtUp.BankMockServer.Entities;
using ArtUp.BankMockServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtUp.BankMockServer.Context;

namespace ArtUp.BankMockServer.Repositories
{
    public class TrasactionRepository : IRepository<Transaction>
    {
        private BankContext db;

        public TrasactionRepository(BankContext c)
        {
            db = c;
        }
        public void Create(Transaction item)
        {
            db.Transactions.Add(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> Find(Func<Transaction, bool> predicate)
        {
            return db.Transactions.Where(predicate).ToList();
        }

        public Transaction Get(int id)
        {
            return db.Transactions.Find(id);
        }

        public IEnumerable<Transaction> GetAll()
        {
            return db.Transactions;
        }

        public void Update(Transaction item)
        {
            throw new NotImplementedException();
        }
    }
}
