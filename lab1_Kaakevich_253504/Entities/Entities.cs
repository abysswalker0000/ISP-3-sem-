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
        private MyCustomCollection<Tariff> tariffs;
        private MyCustomCollection<Tenant> tenants;
        private MyCustomCollection<Tuple<string, string, int>> utilityUsage;

        public UtilityUsage()
        {
            tariffs = new MyCustomCollection<Tariff>();
            tenants = new MyCustomCollection<Tenant>();
            utilityUsage = new MyCustomCollection<Tuple<string, string, int>>();
        }

        public void AddTariff(string utilityName, decimal tariff)
        {
            tariffs.Add(new Tariff { UtilityName = utilityName, Rate = tariff });
            tariffs.OnCollectionChanged();
        }

        public void AddTenant(string tenantName)
        {
            tenants.Add(new Tenant { Name = tenantName });
            tenants.OnCollectionChanged();
        }

        public void AddUtilityUsage(string tenantName, string utilityName, int usageAmount)
        {
            utilityUsage.Add(Tuple.Create(tenantName, utilityName, usageAmount));
            utilityUsage.OnCollectionChanged();
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
            for (int i = 0; i < tariffs.Count; i++)
            {
                if (tariffs[i].UtilityName == utilityName)
                {
                    return tariffs[i];
                }
            }
            return null;
        }

        public MyCustomCollection<Tariff> GetTariffs()
        {
            return tariffs;
        }

        public MyCustomCollection<Tenant> GetTenants()
        {
            return tenants;
        }

        public MyCustomCollection<Tuple<string, string, int>> GetUtilityUsage()
        {
            return utilityUsage;
        }
    }
}
