using System;
using System.Linq;
using System.Collections.Generic;
using ORM.InfraStructures;
using Services.Interfaces;
using System.Linq.Expressions;

namespace Services.ExtentionServices
{
    public class BaseService<Entity> : IActions<Entity>  where Entity : class
    {
        protected TheDbContext context;
        public BaseService(TheDbContext _context)
        {
            context = _context;
        }

        

        public void Delete(Entity obj)
        {
            context.Set<Entity>().Remove(obj);
        }

        public void Delete(IQueryable<Entity> objs)
        {
            context.Set<Entity>().RemoveRange(objs.ToList());
        }

        public void Delete<IdEntity>(IdEntity id) where IdEntity : class
        {
            Delete(GetById<IdEntity>(id));
        }

        public IQueryable<Entity> Get(Expression<Func<Entity, bool>> query)
        {
            return context.Set<Entity>().Where(query);
        }

        public Entity GetById<IdEntity>(IdEntity id) where IdEntity : class
        {
            return context.Set<Entity>().Find(id);
        }

        public void Insert(Entity obj)
        {
            context.Set<Entity>().Add(obj);
        }
        public void Insert(IQueryable<Entity> objs)
        {
            context.Set<Entity>().AddRange(objs.ToList());
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}