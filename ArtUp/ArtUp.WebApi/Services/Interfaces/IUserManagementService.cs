using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUp.WebApi.Services.Interfaces
{
    public interface IUserManagementService
    {
        void CreateUser(string login, string password);
    }
}
