using SensorsSystem.DataLayer.Contracts;
using SensorsSystem.DataLayer.Contracts.FileSystem;
using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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
            _rootDirectory = Path.Combine(Directory.GetCurrentDirectory(), typeof(T).Name);

            var modelName = this.GetType().GetGenericArguments().First().Name;
            EnsureDirectoryCreated(modelName);
        }

        public async Task<T> Add(T item)
        {
            var fileStream = GetLastFileStream(FileAccess.Write);
            await _fileManager.CreateWriter(fileStream).Write(item);

            return item;
        }

        public Task<T> Find(Expression<Func<T, bool>> expression)
        {
            //Mocked data for now
            return Task.FromResult(new T());
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

        private FileStream GetLastFileStream(FileAccess fileAccess)
        {
            var fileNames = Directory.GetFiles(_rootDirectory);
            if (fileNames.Length == 0)
            {
                return File.Open(Path.Combine(_rootDirectory, $"{Guid.NewGuid().ToString()}.json"), FileMode.Create, fileAccess);
            }
            Array.Sort(fileNames);

            return File.Open(Path.Combine(_rootDirectory, fileNames.Last()), FileMode.Append, fileAccess);
        }
    }
}
