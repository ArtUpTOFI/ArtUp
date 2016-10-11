using ArtUp.DataAccess.DataContext;
using ArtUp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ArtUp.DataAccess.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private ArtUpDataContextEF _context;

        public CommentRepository(ArtUpDataContextEF context)
        {
            _context = context;
        }

        public void Create(Comment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Comment entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> Find(Expression<Func<Comment, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Comment Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
