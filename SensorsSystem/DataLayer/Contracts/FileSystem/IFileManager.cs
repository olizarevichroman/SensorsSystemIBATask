using System.IO;

namespace SensorsSystem.DataLayer.Contracts.FileSystem
{
    public interface IFileManager<T> where T: class
    {
        IFileReader<T> CreateReader(Stream stream);
        IFileReader<T> CreateReader(string filePath);
        IFileWriter<T> CreateWriter(Stream stream);
        IFileWriter<T> CreateWriter(string filePath);
    }
}
