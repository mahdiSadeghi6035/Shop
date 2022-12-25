using System;
using System.Linq.Expressions;

namespace _0_Framework.Domain
{
    public interface IRepository <Tkey, T> where T : class
    {
        T GetBy(Tkey id);
        bool Exists(Expression<Func<T, bool>> expression);
        void Create(T command);
        void SaveChanges();
    }
}
