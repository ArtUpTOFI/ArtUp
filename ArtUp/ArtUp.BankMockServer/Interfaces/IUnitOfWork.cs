using ArtUp.BankMockServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUp.BankMockServer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        ICardRepository Cards { get; }
        IRepository<Transaction> Transactions { get; }
        void Save();
    }
}
