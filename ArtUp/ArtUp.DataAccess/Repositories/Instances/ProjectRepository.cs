using ArtUp.DataAccess.DataContext;
using ArtUp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ArtUp.DataAccess.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private ArtUpDataContextEF _context;

        public ProjectRepository(ArtUpDataContextEF context)
        {
            _context = context;
        }

        public void Create(Project entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Project entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> Find(Expression<Func<Project, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Project Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Project> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Project entity)
        {
            throw new NotImplementedException();
        }
    }
}
