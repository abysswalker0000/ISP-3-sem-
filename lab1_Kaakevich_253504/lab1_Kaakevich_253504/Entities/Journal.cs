using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_Kaakevich_253504.Entities
{
     public class Journal
    {
        private List<string> events = new List<string>();

        public void RegisterEvent(object sender,string eventDescription)
        {
            events.Add(eventDescription);
        }

        public void PrintEvents()
        {
            foreach (var evt in events)
            {
                Console.WriteLine(evt);
            }
        }
    }
}
