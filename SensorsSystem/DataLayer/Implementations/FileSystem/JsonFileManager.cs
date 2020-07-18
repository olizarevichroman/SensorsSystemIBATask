using SensorsSystem.DataLayer.Contracts;
using SensorsSystem.DataLayer.Contracts.FileSystem;
using SensorsSystem.DataLayer.Implementations.FileSystem.Readers;
using System.IO;

namespace SensorsSystem.DataLayer.Implementations.FileSystem
{
    public class JsonFileManager<T> : IFileManager<T> where T: class
    {
        public IFileReader<T> CreateReader(Stream stream)
        {
            return new JsonFileReader<T>(stream);
        }

        public IFileReader<T> CreateReader(string filePath)
        {
            return new JsonFileReader<T>(filePath);
        }

        public IFileWriter<T> CreateWriter(Stream stream)
        {
            return new JsonFileWriter<T>(stream);
        }

        public IFileWriter<T> CreateWriter(string filePath)
        {
            return new JsonFileWriter<T>(filePath);
        }
    }
}
