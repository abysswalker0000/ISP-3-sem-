using lab1_Kaakevich_253504.Entities;
using System;

class Program
{
    static void Main(string[] args)
    {
        
        var utilitySystem = new UtilityUsage();
        var journal = new Journal();


        utilitySystem.GetTariffs().CollectionChanged += (sender, eventArgs) =>
        {
            journal.RegisterEvent("Изменение списка тарифов");
        };
        utilitySystem.GetTenants().CollectionChanged += (sender, eventArgs) =>
        {
            journal.RegisterEvent("Изменение списка жильцов");
        };

        utilitySystem.GetUtilityUsage().CollectionChanged += (sender, eventArgs) =>
        {
            journal.RegisterEvent("Покупка услуги жильцом");
        };

        try
        {
           
            utilitySystem.AddTariff("Электричество", 3m);
            utilitySystem.AddTariff("Вода", 2m);

            utilitySystem.AddTenant("Крендель");
            utilitySystem.AddTenant("Боров");

            utilitySystem.AddUtilityUsage("Крендель", "Электричество", 100);
            utilitySystem.AddUtilityUsage("Боров", "Электричество", 150);
            utilitySystem.AddUtilityUsage("Боров", "Вода", 200);

            Console.WriteLine("Тарифы:");
            for (int i = 0; i < utilitySystem.GetTariffs().Count; i++)
            {
                Console.WriteLine(utilitySystem.GetTariffs()[i].UtilityName + ": " + utilitySystem.GetTariffs()[i].Rate);
            }

            Console.WriteLine("\nЖильцы:");
            for (int i = 0; i < utilitySystem.GetTenants().Count; i++)
            {
                Console.WriteLine(utilitySystem.GetTenants()[i].Name);
            }

            Console.WriteLine("\nПотребление:");
            for (int i = 0; i < utilitySystem.GetUtilityUsage().Count; i++)
            {
                var usage = utilitySystem.GetUtilityUsage()[i];
                Console.WriteLine("Жилец: " + usage.Item1 + ", Услуга: " + usage.Item2 + ", Потребление: " + usage.Item3);
            }

            Console.WriteLine("\nОбщая стоимость услуг для Крендель: " + utilitySystem.CalculateTotalUsageCost("Крендель"));
            Console.WriteLine("Общая стоимость услуг для Боров: " + utilitySystem.CalculateTotalUsageCost("Боров"));

            Console.WriteLine("Общая стоимость всех услуг: " + utilitySystem.CalculateTotalBillingAmount());

            Console.WriteLine("Общее количество заказов на электричество: " + utilitySystem.GetTotalOrdersForUtility("Электричество"));
            Console.WriteLine("Общее количество заказов на воду: " + utilitySystem.GetTotalOrdersForUtility("Вода"));
            Console.WriteLine(utilitySystem.GetTariffs()[10]); // IndexOutOfRangeException
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
            journal.RegisterEvent($"Ошибка: {ex.Message}");
        }
        Console.WriteLine("журнал:");
        journal.PrintEvents();
        
    }

}
