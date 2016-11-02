using ArtUp.DataAccess.DataContext;
using ArtUp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ArtUp.DataAccess.Repositories
{
    public class UserDonationRepository : IUserDonationRepository
    {
        private ArtUpDataContextEF _context;
        
        public UserDonationRepository(ArtUpDataContextEF context)
        {
            _context = context;
        }

        public void Create(UserDonation entity)
        {
            _context.UserDonations.Add(entity);
        }

        public void Delete(int id)
        {
            UserDonation ud = _context.UserDonations.Find(id);
            if (ud != null)
                _context.UserDonations.Remove(ud);
        }

        public IEnumerable<UserDonation> Find(Expression<Func<UserDonation, bool>> filter)
        {
            return _context.UserDonations.Where(filter).ToList();
        }

        public UserDonation Get(int id)
        {
            return _context.UserDonations.Find(id);
        }

        public IQueryable<UserDonation> GetAll()
        {
            return _context.UserDonations;
        }

        public void Update(UserDonation entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
