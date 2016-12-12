using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtUp.DataAccess.Entities;
using ArtUp.Client.Models;

namespace ArtUp.Client.Services.Interfaces
{
    public interface IUserManagementService
    {
        void CreateUser(string login, string password);

        User GetByName(string name);

        //bad method, later should be replaced
        int GetCurrentUser(string email);

        IEnumerable<UserViewModel> GetAllUsers();

        void DeactiveUser(int userId);

        UserViewModel GetUser(int id);
    }
}
