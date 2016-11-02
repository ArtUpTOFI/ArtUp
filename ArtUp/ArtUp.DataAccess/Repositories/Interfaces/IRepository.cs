using ArtUp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ArtUp.DataAccess.Repositories
{
    public interface IRepository<Entity> where Entity: class
    {
        IQueryable<Entity> GetAll();

        IEnumerable<Entity> Find(Expression<Func<Entity, bool>> filter);

        Entity Get(int id);

        void Create(Entity entity);

        void Delete(int id);

        void Update(Entity entity);
    }
}
