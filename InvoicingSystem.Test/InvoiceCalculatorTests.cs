using InvoicingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingSystem.Test
{
    public class InvoiceCalculatorTests
    {
        [Fact]
        public void ShouldComputeCorrectValues_WhenUsageIsWithinFirst10kApiCalls()
        {
            // Arrange
            var entry = new UsageRequest
            {
                CustomerId = "CUST001",
                API_Calls = 8500,
                Storage_GB = 45.5,
                Compute_Minutes = 150
            };

            // Act
            var result = InvoiceCalculator.Calculate(entry);

            // Assert
            Assert.Equal(85.00, result.ApiCost, 2);
            Assert.Equal(11.38, result.StorageCost, 2);
            Assert.Equal(7.50, result.ComputeCost, 2);
            Assert.Equal(103.88, result.Total, 2);
        }

        [Fact]
        public void ShouldComputeCorrectValues_WhenUsageIsGreaterThan10kApiCalls()
        {
            // Arrange
            var entry = new UsageRequest
            {
                CustomerId = "CUST002",
                API_Calls = 12500,
                Storage_GB = 120,
                Compute_Minutes = 310
            };

            // Act
            var result = InvoiceCalculator.Calculate(entry);

            // Assert
            Assert.Equal(120.00, result.ApiCost, 2);
            Assert.Equal(30.00, result.StorageCost, 2);
            Assert.Equal(15.50, result.ComputeCost, 2);
            Assert.Equal(165.50, result.Total, 2);
        }

    }
}
