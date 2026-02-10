namespace InvoicingSystem.Models
{
    /// <summary>
    /// Represents the calculated invoice result for a customer,
    /// including individual service costs and the total amount.
    /// </summary>
    public class InvoiceResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the customer.
        /// </summary>
        public required string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the calculated cost for API usage.
        /// </summary>
        public double ApiCost { get; set; }

        /// <summary>
        /// Gets or sets the calculated cost for storage usage.
        /// </summary>
        public double StorageCost { get; set; }

        /// <summary>
        /// Gets or sets the calculated cost for compute usage.
        /// </summary>
        public double ComputeCost { get; set; }

        /// <summary>
        /// Gets the total invoice amount calculated as the sum of
        /// API, storage, and compute costs.
        /// </summary>
        public double Total => ApiCost + StorageCost + ComputeCost;
    }
}
