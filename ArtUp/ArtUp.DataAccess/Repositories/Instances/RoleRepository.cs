using ArtUp.DataAccess.DataContext;
using ArtUp.DataAccess.Entities;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public void Delete(Role entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> Find(Expression<Func<Role, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Role Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Role> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
