using lab1_Kaakevich_253504.Collections;
using lab1_Kaakevich_253504.Conrtacts;
using Generic.Math;

namespace lab1_Kaakevich_253504.Entities
{
    public class Tariff
    {
        public string UtilityName { get; set; }
        public decimal Rate { get; set; }
    }

    public class Tenant
    {
        public string Name { get; set; }
    }

    public class UtilityUsage : IUtilityBillingSystem
    {
        private Dictionary<string, Tariff> tariffs;
        private List<Tenant> tenants;
        private List<Tuple<string, string, int>> utilityUsage;
        public Journal journal;
        public UtilityUsage()
        {
            tariffs = new Dictionary<string, Tariff>();
            tenants = new List<Tenant>();
            utilityUsage = new List<Tuple<string, string, int>>();
            journal = new Journal();
        }
        public List<Tariff> GetTariffs()
        {
            return tariffs.Values.ToList();
        }

        public List<Tenant> GetTenants()
        {
            return tenants;
        }

        public List<Tuple<string, string, int>> GetUtilityUsage()
        {
            return utilityUsage;
        }

        public void AddTariff(string utilityName, decimal tariff)
        {
            tariffs.Add(utilityName, new Tariff { UtilityName = utilityName, Rate = tariff });
            journal.RegisterEvent(this, $"Добавлен новый тариф: {utilityName}");
        }

        public void AddTenant(string tenantName)
        {
            tenants.Add(new Tenant { Name = tenantName });
            journal.RegisterEvent(this, $"Добавлен новый жилец: {tenantName}");
        }

        public void AddUtilityUsage(string tenantName, string utilityName, int usageAmount)
        {
            utilityUsage.Add(Tuple.Create(tenantName, utilityName, usageAmount));
        }

        public decimal CalculateTotalUsageCost(string tenantName)
        {
            decimal totalCost = 0;
            for (int i = 0; i < utilityUsage.Count; i++)
            {
                if (utilityUsage[i].Item1 == tenantName)
                {
                    var tariff = FindTariff(utilityUsage[i].Item2);
                    if (tariff != null)
                    {
                        totalCost = GenericMath<decimal>.Add(totalCost, GenericMath<decimal>.Multiply(tariff.Rate, utilityUsage[i].Item3));
                    }
                }
            }
            return totalCost;
        }

        public decimal CalculateTotalBillingAmount()
        {
            decimal totalAmount = 0;
            for (int i = 0; i < utilityUsage.Count; i++)
            {
                var tariff = FindTariff(utilityUsage[i].Item2);
                if (tariff != null)
                {
                    totalAmount = GenericMath<decimal>.Add(totalAmount, GenericMath<decimal>.Multiply(tariff.Rate, utilityUsage[i].Item3));
                }
            }
            return totalAmount;
        }

        public int GetTotalOrdersForUtility(string utilityName)
        {
            int totalOrders = 0;
            for (int i = 0; i < utilityUsage.Count; i++)
            {
                if (utilityUsage[i].Item2 == utilityName)
                {
                    totalOrders = GenericMath<int>.Add(totalOrders, 1);
                }
            }
            return totalOrders;
        }

        private Tariff FindTariff(string utilityName)
        {
            foreach (var tariff in tariffs.Values)
            {
                if (tariff.UtilityName == utilityName)
                {
                    return tariff;
                }
            }
            return null;
        }

        public List<string> GetSortedUtilityNamesByCost()
        {
            return tariffs.Values.OrderBy(t => t.Rate).Select(t => $"{t.UtilityName} - {t.Rate}").ToList();
        }

        public decimal CalculateTotalUtilityCost()
        {
            return utilityUsage.Sum(u => tariffs.GetValueOrDefault(u.Item2)?.Rate * u.Item3 ?? 0);
        }

        public decimal CalculateTotalTenantCost(string tenantName)
        {
            return utilityUsage.Where(u => u.Item1 == tenantName)
                .Sum(u => tariffs.GetValueOrDefault(u.Item2)?.Rate * u.Item3 ?? 0);
        }

        public string GetTenantWithMaxPayment()
        {
            var maxPayment = tenants.Select(t => new { TenantName = t.Name, TotalCost = CalculateTotalTenantCost(t.Name) })
                                   .OrderByDescending(x => x.TotalCost)
                                   .FirstOrDefault();
            return $"{maxPayment?.TenantName} - {maxPayment?.TotalCost}";
        }

        public int GetTenantsPayingAbove(decimal amount)
        {
            return tenants.Count(t => CalculateTotalTenantCost(t.Name) > amount);
        }

        public Dictionary<string, decimal> GetTenantPaymentsByUtility()
        {
            var paymentsByUtility = new Dictionary<string, decimal>();
            foreach (var usage in utilityUsage)
            {
                string tenantName = usage.Item1;
                string utilityName = usage.Item2;
                decimal cost = usage.Item3 * tariffs.GetValueOrDefault(utilityName)?.Rate ?? 0;
                string key = $"{tenantName} - {utilityName}";
                if (paymentsByUtility.ContainsKey(key))
                {
                    paymentsByUtility[key] += cost;
                }
                else
                {
                    paymentsByUtility[key] = cost;
                }
            }
            return paymentsByUtility;
        }
    }
}
