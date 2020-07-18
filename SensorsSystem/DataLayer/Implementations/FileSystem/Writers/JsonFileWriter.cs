using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SensorsSystem.DataLayer.Contracts;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace SensorsSystem.DataLayer.Implementations.FileSystem.Writers
{
    public class JsonFileWriter<T> : IFileWriter<T> where T : class
    {
        private readonly FileStream _fileStream;
        public JsonFileWriter(FileStream fileStream)
        {
            _fileStream = fileStream;
        }
        public async Task Write(T item)
        {
            using var jsonTextWrite = new JsonTextWriter(new StreamWriter(_fileStream));
            if (_fileStream.Length == 0)
            {
                await jsonTextWrite.WriteStartArrayAsync();
            }
            var serializedData = JsonConvert.SerializeObject(item);

            await jsonTextWrite.WriteValueAsync(serializedData);
        }
    }
}
