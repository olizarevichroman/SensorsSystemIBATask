using System.Threading.Tasks;

namespace SensorsSystem.DataLayer.Contracts
{
    public interface IFileWriter<in T> where T: class
    {
        Task Write(T item);
    }
}
