using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_253504_kazakevich.Entities
{
    internal class PassengerComparer : IComparer<Passenger>
    {
        public int Compare(Passenger? x, Passenger? y)
        {
            if (x is null || y is null)
            {
                return -1;
            }
            return x.Name!.CompareTo(y.Name);
        }
    }
}
