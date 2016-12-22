using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtUp.DataAccess.DataContext;
using ArtUp.DataAccess.Entities;
using ArtUp.DataAccess.Repositories;
using ArtUp.Client.Services.Interfaces;
using ArtUp.Client.Models;

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
                    RoleId = 2,
                    IsActive = true,
                };

                _dataBase.Users.Create(nu);
                _dataBase.SaveAll();
            }
        }

        public User GetByName(string name)
        {
            return _dataBase.Users.Find(u => u.Email == name).FirstOrDefault();
        }

        //bad method, should be replaced later
        public int GetCurrentUser(string email)
        {
            return _dataBase.Users.Find(u => u.Email == email && u.IsActive).FirstOrDefault().Id;
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            return _dataBase.Users.GetAll().Select(u => new UserViewModel()
            {
                Id = u.Id,
                Email = u.Email,
                Avatar = u.Avatar,
                Name = u.Name,
                Surname = u.Surname,
                IsActive = u.IsActive,
                RegistrationDate = u.RegistrationDate,
                Location = u.Location,
                About = u.About
            }).ToList();
        }

        public void DeactiveUser(int userId)
        {
            var user = _dataBase.Users.Get(userId);
            user.IsActive = !user.IsActive;
            _dataBase.Users.Update(user);
            _dataBase.SaveAll();
        }

        public UserViewModel GetUser(int id)
        {
            var u = _dataBase.Users.Get(id);
            return new UserViewModel
            {
                Id = u.Id,
                Email = u.Email,
                IsActive = u.IsActive,
                About = u.About,
                Avatar = u.Avatar,
                Location = u.Location,
                Name = u.Name,
                RegistrationDate = u.RegistrationDate,
                Surname = u.Surname
            };
        }
    }
}