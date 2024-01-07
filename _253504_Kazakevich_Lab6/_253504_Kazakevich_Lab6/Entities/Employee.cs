using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Kazakevich_Lab6.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool ReceivedPremium { get; set; }

        public Employee()
        {
            Name = "";
            ReceivedPremium = false;
            Id = -1;
        }

        public override string ToString()
        {
            return $"#{Id} : {Name},   " +
                   $"{(ReceivedPremium ? "received" : "doesn't received ")} premium";
        }
    }
}
