using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SensorsSystem.DataLayer.Contracts
{
    public interface IFileSystemManager<T> where T: class
    {
        Task<T> Add(T item);
        Task<T> Find(Expression<Func<T, bool>> expression);
    }
}
