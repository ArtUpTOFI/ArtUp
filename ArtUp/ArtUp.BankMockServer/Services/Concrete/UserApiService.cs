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
            bool withdrowResult = false, transferResult = false;
            if ( account != null && CheckAmount(account, amount))
            {
                var targetAccount = database.Accounts.GetByNumber(targetAccountNumber);
                if (targetAccount != null)
                {
                    lock (mainLock)
                    {
                        withdrowResult = database.Accounts.ToWithdrawMoneyFromAccount(account, amount);
                        transferResult = database.Accounts.TransferMoneyToAccount(targetAccount, amount);
                    }
                    if (withdrowResult == true && transferResult == true)
                    {
                        var transaction = new Transaction
                        {
                            Money = amount,
                            TargetAccountId = targetAccount.Id.ToString(),
                            AccountId = account.Id,
                            TransactionDate = DateTime.Now
                        };

                        database.Transactions.Create(transaction);
                        return new Tuple<bool, string>(true, "OK");
                    }
                    return new Tuple<bool, string>(false, "Error with transaction");
                }
                return new Tuple<bool, string>(false, "Incorrect target account");
            }
            else
            {
                return new Tuple<bool, string>(false, "Malo deneg!!!");
            }
        }
        public Tuple<bool, string> CreateTransaction(string cardNumber, string targetAccountNumber, int CVV2, string EndDate, string FirstName, string LastName, float amount)
        {
            var card = database.Cards.GetcardByNumber(cardNumber);
            if(card != null && card.CVV2 == CVV2 && card.EndDate == EndDate && card.FirstName == FirstName && card.LastName == LastName)
            {
                var account = database.Accounts.Get(card.AccountId.Value);
                bool withdrowResult = false, transferResult = false;
                if (account != null && CheckAmount(account, amount))
            {
                var targetAccount = database.Accounts.GetByNumber(targetAccountNumber);
                    if (targetAccount != null)
                    {
                        lock (mainLock)
                {
                            withdrowResult = database.Accounts.ToWithdrawMoneyFromAccount(account, amount);
                            transferResult = database.Accounts.TransferMoneyToAccount(targetAccount, amount);
                }
                        if (withdrowResult == true && transferResult == true)
                        {
                            var transaction = new Transaction
                            {
                                Card = cardNumber,
                                Money = amount,
                                TargetAccountId = targetAccount.Id.ToString(),
                                AccountId = account.Id,
                                TransactionDate = DateTime.Now
                            };

                            database.Transactions.Create(transaction);
                            return new Tuple<bool, string>(true, "OK");
                        }
                        return new Tuple<bool, string>(false, "Error with transaction");
            }
                    return new Tuple<bool, string>(false, "iNCORRECT TARGET ACCOUNT");
        }
                else
        {
                    return new Tuple<bool, string>(false, "Malo deneg!!!");
                }
            }
            return new Tuple<bool, string>(false, "Incorrect card attributes");
        }

        public Tuple<bool, string> CardTransaction(string accountNumber, string targetCardNumber, float amount)
        {
            var account = database.Accounts.GetByNumber(accountNumber);
            if(account == null)
            {
                return new Tuple<bool, string>(false, "Неверно указан счет");
            }
            bool withdrowResult = false, transferResult = false;
            if (account != null && CheckAmount(account, amount))
            {
                var targetCard = database.Cards.GetcardByNumber(targetCardNumber);
                if (targetCard == null)
                {
                    return new Tuple<bool, string>(false, "Неверно указана карта");
                }
                var targetAccount = database.Accounts.Get(targetCard.AccountId.Value);
                if (targetCard != null)
                {
                    lock (mainLock)
                    {
                        withdrowResult = database.Accounts.ToWithdrawMoneyFromAccount(account, amount);
                        transferResult = database.Accounts.TransferMoneyToAccount(targetAccount, amount);
                    }
                    if (withdrowResult == true && transferResult == true)
                    {
                        var transaction = new Transaction
                        {
                            Money = amount,
                            TargetAccountId = targetAccount.Id.ToString(),
                            AccountId = account.Id,
                            TransactionDate = DateTime.Now
                        };

                        database.Transactions.Create(transaction);
                        return new Tuple<bool, string>(true, "OK");
                    }
                    return new Tuple<bool, string>(false, "Error with transaction");
                }
                return new Tuple<bool, string>(false, "Incorrect target account");
            }
            else
            {
                return new Tuple<bool, string>(false, "Malo deneg!!!");
            }
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

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return database.Transactions.GetAll();
        }

        private bool CheckAmount(Account account, float amount)
        {
            return account.Money > amount;
        }
    }
}
