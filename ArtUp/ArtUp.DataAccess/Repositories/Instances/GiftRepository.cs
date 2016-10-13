using ArtUp.DataAccess.DataContext;
using ArtUp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ArtUp.DataAccess.Repositories
{
    public class GiftRepository : IGiftRepository
    {
        private ArtUpDataContextEF _context;

        public GiftRepository(ArtUpDataContextEF context)
        {
            _context = context;
        }

        public void Create(Gift entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Gift entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Gift> Find(Expression<Func<Gift, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Gift Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Gift> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Gift entity)
        {
            throw new NotImplementedException();
        }
    }
}
