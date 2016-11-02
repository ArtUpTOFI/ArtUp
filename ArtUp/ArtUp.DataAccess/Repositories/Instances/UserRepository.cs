using ArtUp.DataAccess.DataContext;
using ArtUp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ArtUp.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ArtUpDataContextEF _context;
        
        public  UserRepository(ArtUpDataContextEF context)
        {
            _context = context;
        }

        public void Create(User entity)
        {
            _context.Users.Add(entity);
        }

        public void Delete(int id)
        {
            User user = _context.Users.Find(id);
            if (user != null)
                _context.Users.Remove(user);
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> filter)
        {
            return _context.Users.Where(filter).ToList();
        }

        public User Get(int id)
        {
            return _context.Users.Find(id);
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users;
        }

        public void Update(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
