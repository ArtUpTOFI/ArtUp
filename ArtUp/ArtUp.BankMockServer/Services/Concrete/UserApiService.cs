using ArtUp.BankMockServer.Common;
using ArtUp.BankMockServer.Entities;
using ArtUp.BankMockServer.Interfaces;
using ArtUp.BankMockServer.Services.Intarfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUp.BankMockServer.Services.Concrete
{
    public class UserApiService : IUserApiService
    {
        private IUnitOfWork database;
        private object mainLock = new object();
        public UserApiService()
        {
            var inst = InstanseCreator<UnitOfWork>.GetInstance("BankConnection");
            database = inst as IUnitOfWork;
        }

        public Tuple<bool, string> CreateTransaction(string accountNumber, string targetAccountNumber, float amount)
        {
            var account = database.Accounts.GetByNumber(accountNumber);
            if(CheckAmount(account, amount))
            {
                var targetAccount = database.Accounts.GetByNumber(targetAccountNumber);
                lock(mainLock)
                {
                    account.Money -= amount;
                    targetAccount.Money += amount;
                }
            }

            var result = new Tuple<bool, string>(true, "OK");
            return result;
        }
        public Tuple<bool, string> CreateTransaction(string cardNumber, string targetAccountNumber, int CVV2, string EndDate, string FirstName, string LastName, string billingAdress, float amount)
        {
            var account = database.Accounts.Get();

            var result = new Tuple<bool, string>(true, "OK");
            return result;
        }


        public Account GetAccount(int id)
        {
            return database.Accounts.Get(id);
        }

        public Account GetAccountByNumber(string number)
        {
            return database.Accounts.GetByNumber(number);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return database.Accounts.GetAll();
        }

        public IEnumerable<Transaction> GetAllTransactionsWithAccount(int id)
        {
            return database.Transactions.Find(t => t.AccountId == id);
        }

        public IEnumerable<Transaction> GetAllTransactionsWithAccountNumber(string number)
        {
            var targetAccount = database.Accounts.GetByNumber(number);
            return database.Transactions.Find(t =>t.AccountId == targetAccount.Id);
        }

        private bool CheckAmount(Account account, float amount)
        {
            return account.Money > amount;
        }
    }
}
