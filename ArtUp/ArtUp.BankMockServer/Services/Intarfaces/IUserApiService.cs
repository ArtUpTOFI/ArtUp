using ArtUp.BankMockServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUp.BankMockServer.Services.Intarfaces
{
    public interface IUserApiService
    {
        IEnumerable<Transaction> GetAllTransactionsWithAccount(int id);

        IEnumerable<Transaction> GetAllTransactionsWithAccountNumber(string number);

        Account GetAccount(int id);

        Account GetAccountByNumber(string number);

        Tuple<bool, string> CreateTransaction(string accountNumber, string targetAccountNumber, float amount);

        Tuple<bool, string> CreateTransaction(string cardNumber, string targetAccountNumber, int CVV2, string EndDate, string FirstName, string LastName, float amount);

        IEnumerable<Transaction> GetAllTransactions();
    }
}
