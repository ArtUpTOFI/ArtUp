using ArtUp.BankMockServer.Common;
using ArtUp.BankMockServer.Entities;
using ArtUp.BankMockServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUp.BankMockServer.Services.Concrete
{
    public class UserApiService
    {
        private IUnitOfWork database;
        public UserApiService()
        {
            var inst = InstanseCreator<UnitOfWork>.GetInstance("BankConnection");
            database = inst as IUnitOfWork;
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return database.Accounts.GetAll();
        }
    }
}
