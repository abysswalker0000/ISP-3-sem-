using lab4_253504_kazakevich.Entities;
using lab4_253504_kazakevich.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_253504_kazakevich.Services
{
    internal class PassengerSerializer : ISerializer<Passenger>
    {
        public void Serialize(IEnumerable<Passenger> data, string fileName)
        {
            using var stream = File.OpenWrite(fileName);
            var writer = new BinaryWriter(stream);
            foreach (var obj in data)
            {
                writer.Write(obj.Name!);
                writer.Write(obj.Age);
                writer.Write(obj.HasTicket);
            }
        }

        public IEnumerable<Passenger> Deserialize(string fileName)
        {
            using var stream = File.OpenRead(fileName);
            var reader = new BinaryReader(stream);
            while (reader.PeekChar() != -1)
            {
                var name= reader.ReadString();
                var age = reader.ReadInt32();
                var hasTicket = reader.ReadBoolean();
                yield return new Passenger()
                {
                    Name = name,
                    Age=age,
                    HasTicket = hasTicket
                };
            }
            reader.Close();
            stream.Close();
        }
    }
}
