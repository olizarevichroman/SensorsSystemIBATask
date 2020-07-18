using Newtonsoft.Json;
using SensorsSystem.DataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SensorsSystem.DataLayer.Implementations.FileSystem.Readers
{
    public class JsonFileReader<T> : IFileReader<T> where T : class
    {
        private readonly Stream _stream;
        public JsonFileReader(Stream stream)
        {
            _stream = stream;
        }

        public JsonFileReader(string path)
        {
            _stream = File.OpenRead(path);
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetNext()
        {
            throw new NotImplementedException();
            //var jsonTextReader = new JsonTextReader(new StreamReader(_stream));
            //jsonTextReader.
        }
    }
}
