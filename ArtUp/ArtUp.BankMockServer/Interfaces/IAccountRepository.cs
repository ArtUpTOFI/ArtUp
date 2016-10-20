using ArtUp.BankMockServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUp.BankMockServer.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetByNumber(string number);

        bool ToWithdrawMoneyFromAccount(Account account, float amount);

        bool TransferMoneyToAccount(Account account, float amount);
    }
}
