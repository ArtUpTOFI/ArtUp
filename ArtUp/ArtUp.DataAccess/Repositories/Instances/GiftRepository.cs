using ArtUp.DataAccess.DataContext;
using ArtUp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            _context.Gifts.Add(entity);
        }

        public void Delete(int id)
        {
            Gift gift = _context.Gifts.Find(id);
            if (gift != null)
                _context.Gifts.Remove(gift);
        }

        public IEnumerable<Gift> Find(Expression<Func<Gift, bool>> filter)
        {
            return _context.Gifts.Where(filter).ToList();
        }

        public Gift Get(int id)
        {
            return _context.Gifts.Find(id);
        }

        public IQueryable<Gift> GetAll()
        {
            return _context.Gifts;
        }

        public void Update(Gift entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
