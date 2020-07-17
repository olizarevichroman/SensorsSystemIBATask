using SensorsSystem.DataLayer.Contracts;
using SensorsSystem.DataLayer.Contracts.FileSystem;
using System;
using System.IO;

namespace SensorsSystem.DataLayer.Implementations.FileSystem
{
    public class JsonFileManager<T> : IFileManager<T> where T: class
    {
        public IFileReader<T> CreateReader(Stream stream)
        {
            throw new NotImplementedException();
        }

        public IFileReader<T> CreateReader(string filePath)
        {
            throw new NotImplementedException();
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
