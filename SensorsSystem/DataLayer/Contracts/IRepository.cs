using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SensorsSystem.DataLayer.Contracts
{
    public interface IRepository<T> where T: class
    {
        Task<T> GetById(object id);

        Task<T> Create(T instance);

        Task<T> Delete(object id);

        Task<T> Update(T entity);

        Task<IEnumerable<T>> GetAll();

        Task<T> Find(Expression<Func<T, bool>> condition);

        Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> condition);
    }
}
