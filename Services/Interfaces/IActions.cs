using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services.Interfaces
{
    public interface IActions<Entity> : IBase
    {
        IQueryable<Entity> Get(Expression<Func<Entity, bool>> query);
        Entity GetById<IdEntity>(IdEntity id) where IdEntity : class;

        void Insert(Entity obj);
        void Insert(IQueryable<Entity> objs);

        void Delete<IdEntity>(IdEntity id)where IdEntity : class;
        void Delete(Entity obj);

        void Delete(IQueryable<Entity> objs);


    }
}