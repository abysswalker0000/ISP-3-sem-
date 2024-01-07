using System;
using lab1_Kaakevich_253504.Entities;

class Program
{
    static void Main(string[] args)
    {
        var utilitySystem = new UtilityUsage();
        var AboveCost = 500;

        utilitySystem.AddTariff("Электричество", 3m);
        utilitySystem.AddTariff("Вода", 2m);
        utilitySystem.AddTariff("Газ", 6m);
        utilitySystem.AddTariff("Что-то еще", 8m);

        utilitySystem.AddTenant("Крендель");
        utilitySystem.AddTenant("Боров");

        utilitySystem.AddUtilityUsage("Крендель", "Электричество", 100);
        utilitySystem.AddUtilityUsage("Боров", "Электричество", 150);
        utilitySystem.AddUtilityUsage("Боров", "Вода", 200);
        utilitySystem.journal.PrintEvents();

        Console.WriteLine("Тарифы:");
        foreach (var tariff in utilitySystem.GetTariffs())
        {
            Console.WriteLine($"{tariff.UtilityName}: {tariff.Rate}");
        }

        Console.WriteLine("\nЖильцы:");
        foreach (var tenant in utilitySystem.GetTenants())
        {
            Console.WriteLine(tenant.Name);
        }

        Console.WriteLine("\nПотребление:");
        foreach (var usage in utilitySystem.GetUtilityUsage())
        {
            Console.WriteLine($"Жилец: {usage.Item1}, Услуга: {usage.Item2}, Потребление: {usage.Item3}");
        }

        Console.WriteLine("\nОбщая стоимость услуг для Крендель: " + utilitySystem.CalculateTotalUsageCost("Крендель"));
        Console.WriteLine("Общая стоимость услуг для Боров: " + utilitySystem.CalculateTotalUsageCost("Боров"));

        Console.WriteLine("Общая стоимость всех услуг: " + utilitySystem.CalculateTotalBillingAmount());

        Console.WriteLine("Общее количество заказов на электричество: " + utilitySystem.GetTotalOrdersForUtility("Электричество"));
        Console.WriteLine("Общее количество заказов на воду: " + utilitySystem.GetTotalOrdersForUtility("Вода"));

        Console.WriteLine("\nСписок услуг, отсортированный по стоимости:");
        foreach (var utilityName in utilitySystem.GetSortedUtilityNamesByCost())
        {
            Console.WriteLine(utilityName);
        }

        Console.WriteLine("\nОбщая стоимость всех выполненных услуг ЖЭС: " + utilitySystem.CalculateTotalUtilityCost());

        Console.WriteLine("\nИмя жильца с максимальной суммой платежей: " + utilitySystem.GetTenantWithMaxPayment());

        int tenantsPayingAboveCount = utilitySystem.GetTenantsPayingAbove(AboveCost);
        Console.WriteLine($"Количество жильцов, заплативших больше {AboveCost}: {tenantsPayingAboveCount}");

        var tenantPaymentsByUtility = utilitySystem.GetTenantPaymentsByUtility();
        Console.WriteLine("\nСуммы, заплаченные жильцами по каждой услуге:");
        var paymentsByUtility = utilitySystem.GetTenantPaymentsByUtility();
        foreach (var payment in paymentsByUtility)
        {
            Console.WriteLine($"{payment.Key}: {payment.Value}");
        }
    }
}
