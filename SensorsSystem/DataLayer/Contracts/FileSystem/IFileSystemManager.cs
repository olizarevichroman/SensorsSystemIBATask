using System.Threading.Tasks;

namespace SensorsSystem.DataLayer.Contracts
{
    public interface IFileSystemManager<T> where T: class
    {
        Task Add(T item);
    }
}
