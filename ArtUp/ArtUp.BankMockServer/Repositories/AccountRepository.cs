using ArtUp.BankMockServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtUp.BankMockServer.Entities;
using ArtUp.BankMockServer.Context;
using System.Data.Entity;

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
            db.SaveChanges();
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
            return db.Accounts.Where(n => n.Nubmer == number).FirstOrDefault();
        }

        public bool ToWithdrawMoneyFromAccount(Account account, float amount)
        {
            var ac = Get(account.Id);
            ac.Money -= amount;
            Update(ac);
            var res = db.SaveChanges();
            return res > 0 ? true : false;
        }

        public bool TransferMoneyToAccount(Account account, float amount)
        {
            var ac = Get(account.Id);
            ac.Money += amount;
            Update(ac);
            var res = db.SaveChanges();
            return res > 0 ? true : false;
        }

        public void Update(Account item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
