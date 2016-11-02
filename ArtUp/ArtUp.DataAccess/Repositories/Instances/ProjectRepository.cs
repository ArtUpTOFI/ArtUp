using ArtUp.DataAccess.DataContext;
using ArtUp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            _context.Projects.Add(entity);
        }

        public void Delete(int id)
        {
            Project project = _context.Projects.Find(id);
            if (project != null)
                _context.Projects.Remove(project);
        }

        public IEnumerable<Project> Find(Expression<Func<Project, bool>> filter)
        {
            return _context.Projects.Where(filter).ToList();
        }

        public Project Get(int id)
        {
            return _context.Projects.Find(id);
        }

        public IQueryable<Project> GetAll()
        {
            return _context.Projects;
        }

        public void Update(Project entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
