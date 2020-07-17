using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorsSystem.DataLayer.Contracts
{
    public interface IFileReader<out T>
    {
        T GetNext();

        IEnumerable<T> GetAll();
    }
}
