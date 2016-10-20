using ArtUp.BankMockServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtUp.BankMockServer.Entities;
using ArtUp.BankMockServer.Context;
using ArtUp.BankMockServer.Repositories;

namespace ArtUp.BankMockServer
{
    public class UnitOfWork : IUnitOfWork
    {
        private BankContext db;
        private AccountRepository accountRepository;
        private CardRepository cardRepository;
        private TransactionRepository transactionRepository;

        public UnitOfWork(string connectionString)
        {
            db = new BankContext(connectionString);
        }
        public IAccountRepository Accounts
        {
            get
            {
                if (accountRepository == null)
                    accountRepository = new AccountRepository(db);
                return accountRepository;
            }
        }

        public ICardRepository Cards
        {
            get
            {
                if (cardRepository == null)
                    cardRepository = new CardRepository(db);
                return cardRepository;
            }
        }

        public IRepository<Transaction> Transactions
        {
            get
            {
                if (transactionRepository == null)
                    transactionRepository = new TransactionRepository(db);
                return transactionRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
