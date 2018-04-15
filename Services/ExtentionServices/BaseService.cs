using System;
using System.Linq;
using System.Collections.Generic;
using ORM.InfraStructures;
using Services.Interfaces;

namespace Services.ExtentionServices
{
    public class BaseService<Entity> : IActions<Entity>
    {
        protected TheDbContext context;
        public BaseService(TheDbContext _context)
        {
            context = _context;
        }

        public IEnumerable<Entity> Get(Func<Entity, bool> fun)
        {
            return null;
        }
    }
}