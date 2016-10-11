using ArtUp.DataAccess.DataContext;
using ArtUp.DataAccess.Entities;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public void Delete(UserDonation entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDonation> Find(Expression<Func<UserDonation, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public UserDonation Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserDonation> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(UserDonation entity)
        {
            throw new NotImplementedException();
        }
    }
}
