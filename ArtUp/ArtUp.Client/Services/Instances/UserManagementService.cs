using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtUp.DataAccess.DataContext;
using ArtUp.DataAccess.Entities;
using ArtUp.DataAccess.Repositories;
using ArtUp.Client.Services.Interfaces;

namespace ArtUp.Client.Services.Instances
{
    public class UserManagementService : IUserManagementService
    {
        private IArtUpData _dataBase;

        public UserManagementService()
        {
            _dataBase = new ArtUpData();
        }
        public void CreateUser(string login, string password)
        {
            if (login != null && password != null)
            {
                var nu = new User
                {
                    Password = password,
                    Email = login,
                    RegistrationDate = DateTime.Now,
                    RoleId = 2
                };

                _dataBase.Users.Create(nu);
                _dataBase.SaveAll();
            }
        }

        public User GetByName(string name)
        {
            return _dataBase.Users.Find(u => u.Email == name).FirstOrDefault();
        }
    }
}