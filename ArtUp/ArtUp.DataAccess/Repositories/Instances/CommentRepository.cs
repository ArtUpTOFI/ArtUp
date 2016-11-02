using ArtUp.DataAccess.DataContext;
using ArtUp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            _context.Comments.Add(entity);
        }

        public void Delete(int id)
        {
            Comment comment = _context.Comments.Find(id);
            if (comment != null)
                _context.Comments.Remove(comment);
        }

        public IEnumerable<Comment> Find(Expression<Func<Comment, bool>> filter)
        {
            return _context.Comments.Where(filter).ToList();
        }

        public Comment Get(int id)
        {
            return _context.Comments.Find(id);
        }

        public IQueryable<Comment> GetAll()
        {
            return _context.Comments;
        }

        public void Update(Comment entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
