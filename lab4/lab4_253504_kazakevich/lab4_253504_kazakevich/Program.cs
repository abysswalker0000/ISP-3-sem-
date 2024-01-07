
using lab4_253504_kazakevich.Entities;
using lab4_253504_kazakevich.Interfaces;
using lab4_253504_kazakevich.Services;

class Program
{
    static void Main(string[] args)
    {
        FileService<Passenger> fileService = new FileService<Passenger>
        {
            Serializer = new PassengerSerializer()
        };

        
        //{
        //    var directory = Directory.GetCurrentDirectory() + "/RANDOMFILES/";
        //    Directory.CreateDirectory(directory);
        //    fileService.CreateFilesWithRandomNames(directory, 10);
        //    foreach (var file in Directory
        //        .GetFiles(directory)                                                          РАНДОМНЫЕ ФАЙЛЫ!!!!!!!!!!!!!!!!!!!!!!!!!!
        //        .Select(file => Path.GetFileName(file)))
        //    {
        //        var parts = file.Split(".");
        //        Console.WriteLine($"File {parts[0]} has .{parts[^1]} extension");
        //    }
        //}



        Passenger f1 = new Passenger("a", 6, false);
        Passenger f2 = new Passenger("b", 5, true);
        Passenger f3 = new Passenger("c", 4, false);
        Passenger f4 = new Passenger("d", 3, true);
        Passenger f5 = new Passenger("e", 2, false);
        Passenger f6 = new Passenger("f", 1, true);
        List<Passenger> passengers = new List<Passenger>
                {
                    f1, f2, f3, f4, f5, f6
                };

        var fileName = "result3.file";
        var newFileName = "new_result3.file";

        try
        {

            fileService.SaveData(passengers, fileName);

         
            File.Move(fileName, newFileName);

         
            var collection = fileService.ReadFile(newFileName);

        
            Console.WriteLine("Data from the file:");
            foreach (var passenger in collection)
            {
                Console.WriteLine($"Name: {passenger.Name}, Age: {passenger.Age}, HasTicket: {passenger.HasTicket}");
            }

   
            Console.WriteLine("\nData sorted by name:");
            var comparer = new PassengerComparer();
            foreach (var passenger in collection.OrderBy(p => p, comparer))
            {
                Console.WriteLine($"Name: {passenger.Name}, Age: {passenger.Age}, HasTicket: {passenger.HasTicket}");
            }

            Console.WriteLine("\nData sorted by age:");
            foreach (var passenger in collection.OrderBy(p => p.Age))
            {
                Console.WriteLine($"Name: {passenger.Name}, Age: {passenger.Age}, HasTicket: {passenger.HasTicket}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

