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
        bool TransferToAccount(float money);

        bool WithdrawFromAccount(float moeny);

        Account GetByNumber(string number);
    }
}
