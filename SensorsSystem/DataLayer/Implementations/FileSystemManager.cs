using SensorsSystem.DataLayer.Contracts;
using SensorsSystem.DataLayer.Contracts.FileSystem;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SensorsSystem.DataLayer.Implementations
{
    public class FileSystemManager<T> : IFileSystemManager<T> where T: class, new()
    {
        private readonly IFileManager<T> _fileManager;
        //need to somehow pass stream of file path into the writer/reader
        //how to combine reader/writer into the 1 instance which will initialize them
        private string _rootDirectory;

        public FileSystemManager(IFileManager<T> fileManager)
        {
            _fileManager = fileManager;

            var modelName = this.GetType().GetGenericArguments().First().Name;
            EnsureDirectoryCreated(modelName);
        }

        public Task Add(T item)
        {
            var filePath = GetLastFilePath();

            return _fileManager.CreateWriter(filePath).Write(item);
        }

        private void EnsureDirectoryCreated(string directoryName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), directoryName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                _rootDirectory = path;
            }
        }

        private string GetLastFilePath()
        {
            var fileNames = Directory.GetFiles(_rootDirectory);
            Array.Sort(fileNames);

            return fileNames.Last();
        }
    }
}
