namespace InvoicingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = args.Length > 0 ? args[0] : "usage-data.json";

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"JSON file not found: {filePath}");
                return;
            }

            Console.WriteLine($"JSON file found: {filePath}");

            var validData = InputLoader.LoadAndValidateData(filePath);

            foreach (var entry in validData)
            {
                var invoice = InvoiceCalculator.Calculate(entry);
                InvoicePrinter.PrintInvoice(invoice, entry);
            }
        }
    }
}
