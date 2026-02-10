using InvoicingSystem.Constants;
using InvoicingSystem.Models;

namespace InvoicingSystem
{
    public static class InvoiceCalculator
    {
        public static InvoiceResult Calculate(UsageRequest entry)
        {
            double apiCost;

            if (entry.API_Calls <= 10000)
            {
                apiCost = entry.API_Calls * PricingRuleConstants.ApiRate_First10k;
            }
            else
            {
                apiCost = 10000 * PricingRuleConstants.ApiRate_First10k +
                          (entry.API_Calls - 10000) * PricingRuleConstants.ApiRate_Above10k;
            }

            double storageCost = entry.Storage_GB * PricingRuleConstants.StorageRate;
            double computeCost = entry.Compute_Minutes * PricingRuleConstants.ComputeRate;

            return new InvoiceResult
            {
                CustomerId = entry.CustomerId,
                ApiCost = Math.Round(apiCost, 2),
                StorageCost = Math.Round(storageCost, 2),
                ComputeCost = Math.Round(computeCost, 2)
            };
        }
    }
}
