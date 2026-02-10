using InvoicingSystem.Models;

namespace InvoicingSystem
{
    public static class InvoicePrinter
    {
        public static void PrintInvoice(InvoiceResult invoice, UsageRequest usage)
        {
            Console.WriteLine();
            Console.WriteLine($"Invoice for Customer: {invoice.CustomerId}");
            Console.WriteLine("----------------------------------");

            Console.WriteLine($"API Calls: ${usage.API_Calls} calls -> ${invoice.ApiCost} \n");
            Console.WriteLine($"Storage:  ${usage.Storage_GB} GB -> ${invoice.StorageCost} \n");
            Console.WriteLine($"Compute Time: ${usage.Compute_Minutes} minutes  -> ${invoice.ComputeCost} \n");

            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Total Due:       -> ${invoice.Total:F2}");
            Console.WriteLine();
        }
    }
}
