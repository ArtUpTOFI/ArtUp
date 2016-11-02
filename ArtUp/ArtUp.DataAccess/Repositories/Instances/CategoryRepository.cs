using ArtUp.DataAccess.DataContext;
using ArtUp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ArtUp.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ArtUpDataContextEF _context;

        public CategoryRepository(ArtUpDataContextEF context)
        {
            _context = context;
        }

        public void Create(Category entity)
        {
            _context.Categories.Add(entity);
        }

        public void Delete(int id)
        {
            Category category = _context.Categories.Find(id);
            if (category != null)
                _context.Categories.Remove(category);
        }

        public IEnumerable<Category> Find(Expression<Func<Category, bool>> filter)
        {
            return _context.Categories.Where(filter).ToList();
        }

        public Category Get(int id)
        {
            return _context.Categories.Find(id);
        }

        public IQueryable<Category> GetAll()
        {
            return _context.Categories;
        }

        public void Update(Category entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
