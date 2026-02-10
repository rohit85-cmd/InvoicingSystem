using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingSystem.Constants
{
    public static class PricingRuleConstants
    {
        public const double ApiRate_First10k = 0.01;
        public const double ApiRate_Above10k = 0.008;
        public const double StorageRate = 0.25;
        public const double ComputeRate = 0.05;
    }
}
