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
    public class AccountRepository : IAccountRepository
    {
        private BankContext db;

        public AccountRepository(BankContext c)
        {
            db = c;
        }
        public void Create(Account item)
        {
            db.Accounts.Add(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> Find(Func<Account, bool> predicate)
        {
            return db.Accounts.Where(predicate).ToList();
        }

        public Account Get(int id)
        {
            return db.Accounts.Find(id);
        }

        public IEnumerable<Account> GetAll()
        {
            return db.Accounts;
        }

        public Account GetByNumber(string number)
        {
            return db.Accounts.Where(n => n.Nubmer == number).First();
        }

        public bool TransferToAccount(float money)
        {
            throw new NotImplementedException();
        }

        public void Update(Account item)
        {
            throw new NotImplementedException();
        }

        public bool WithdrawFromAccount(float moeny)
        {
            throw new NotImplementedException();
        }
    }
}
