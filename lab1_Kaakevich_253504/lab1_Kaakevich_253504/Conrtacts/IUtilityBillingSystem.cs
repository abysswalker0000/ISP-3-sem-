using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_Kaakevich_253504.Conrtacts
{
    public interface IUtilityBillingSystem
    {
        void AddTariff(string utilityName, decimal tariff);
        void AddTenant(string tenantName);
        void AddUtilityUsage(string tenantName, string utilityName, int usageAmount);
        decimal CalculateTotalUsageCost(string tenantName);
        decimal CalculateTotalBillingAmount();
        int GetTotalOrdersForUtility(string utilityName);
    }
}
