using Newtonsoft.Json;
using SensorsSystem.DataLayer.Contracts;
using System.IO;
using System.Threading.Tasks;

namespace SensorsSystem.DataLayer.Implementations.FileSystem
{
    public class JsonFileWriter<T> : IFileWriter<T> where T : class
    {
        private readonly StreamWriter _streamWriter;
        public JsonFileWriter(Stream stream)
        {
            _streamWriter = new StreamWriter(stream);
        }
        public JsonFileWriter(string filePath)
        {
            _streamWriter = new StreamWriter(filePath);
        }
        public async Task Write(T item)
        {
            using var writer = new JsonTextWriter(_streamWriter);
            await writer.WriteValueAsync(item);
        }
    }
}
