using SensorsSystem.DataLayer.Contracts;

namespace SensorsSystem.DataLayer.Implementations
{
    public class FileSystemManager : IFileSystemManager
    {
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;

        //public FileSystemManager(IFileReader fileReader, IFileWriter fileWriter)
        //{
        //    _fileReader = fileReader;
        //    _fileWriter = fileWriter;
        //}
    }
}
