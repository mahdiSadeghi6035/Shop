using _0_Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace _0_Framework.Infrastructure
{
    public class RepositoryBase<Tkey, T> : IRepository<Tkey, T> where T : class
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public void Create(T command)
        {
            _context.Add<T>(command);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public T GetBy(Tkey id)
        {
            return _context.Find<T>(id);
        }

        public void SaveChanges()
        {
            return _context.SavingChanges();
        }
    }
}
