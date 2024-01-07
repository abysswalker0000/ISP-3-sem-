using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_253504_kazakevich.Entities
{
    public class Passenger
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool HasTicket { get; set; }

        public Passenger()
        {
            Name = "";
            Age = 0;
            HasTicket = false;
        }
        public Passenger(string name, int age, bool hasTicket)
        {
            Name = name;
            Age = age;
            HasTicket = hasTicket;
        }
    }
}
