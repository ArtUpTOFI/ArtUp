using ArtUp.DataAccess.DataContext;
using ArtUp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ArtUp.DataAccess.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private ArtUpDataContextEF _context;
        
        public RoleRepository(ArtUpDataContextEF context)
        {
            _context = context;
        }

        public void Create(Role entity)
        {
            _context.Roles.Add(entity);
        }

        public void Delete(int id)
        {
            Role role = _context.Roles.Find(id);
            if (role != null)
                _context.Roles.Remove(role);
        }

        public IEnumerable<Role> Find(Expression<Func<Role, bool>> filter)
        {
            return _context.Roles.Where(filter).ToList();
        }

        public Role Get(int id)
        {
            return _context.Roles.Find(id);
        }

        public IQueryable<Role> GetAll()
        {
            return _context.Roles;
        }

        public void Update(Role entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
