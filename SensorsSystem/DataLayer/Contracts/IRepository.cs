using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SensorsSystem.DataLayer.Contracts
{
    public interface IRepository<T> where T: class
    {
        Task<T> Get(object id);

        Task Add(T instance);

        Task<T> Remove(object id);

        Task<T> Find(Expression<Func<T, bool>> condition);

        Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> condition);
    }
}
