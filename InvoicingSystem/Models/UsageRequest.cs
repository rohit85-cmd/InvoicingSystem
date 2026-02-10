namespace InvoicingSystem.Models
{
    /// <summary>
    /// Represents a request containing usage details for a customer
    /// to calculate billing or generate invoices.
    /// </summary>
    public class UsageRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the customer.
        /// </summary>
        public required string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the total number of API calls made by the customer.
        /// </summary>
        public double API_Calls { get; set; }

        /// <summary>
        /// Gets or sets the amount of storage used by the customer in gigabytes (GB).
        /// </summary>
        public double Storage_GB { get; set; }

        /// <summary>
        /// Gets or sets the total compute time consumed by the customer in minutes.
        /// </summary>
        public double Compute_Minutes { get; set; }
    }
}
