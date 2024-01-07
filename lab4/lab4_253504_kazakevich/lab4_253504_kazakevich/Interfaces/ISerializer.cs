using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_253504_kazakevich.Interfaces
{
    internal interface ISerializer<T>
    {
        void Serialize(IEnumerable<T> data, string fileName);
        IEnumerable<T> Deserialize(string fileName);
    }
}
