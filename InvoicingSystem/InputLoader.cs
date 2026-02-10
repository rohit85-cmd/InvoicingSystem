using InvoicingSystem.Models;
using System.Text.Json;

namespace InvoicingSystem
{
    public class InputLoader
    {
        public static List<UsageRequest> LoadAndValidateData(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            var jsonData = JsonSerializer.Deserialize<List<JsonElement>>(jsonString);

            var validEntries = new List<UsageRequest>();
            foreach (var jsonItem in jsonData!)
            {
                string? customerId = jsonItem.TryGetProperty("CustomerId", out var cusIdProp)
                                    && cusIdProp.ValueKind == JsonValueKind.String
                                    ? cusIdProp.GetString()
                                    : null;

                if (!jsonItem.TryGetProperty("API_Calls", out var apiCallProp) ||
                    !jsonItem.TryGetProperty("Storage_GB", out var storageProp) ||
                    !jsonItem.TryGetProperty("Compute_Minutes", out var computeMinuteProp) ||
                    customerId == null ||
                    apiCallProp.ValueKind != JsonValueKind.Number ||
                    storageProp.ValueKind != JsonValueKind.Number ||
                    computeMinuteProp.ValueKind != JsonValueKind.Number)
                {
                    Console.WriteLine($"Skipped invalid entry: Missing or invalid fields for CustomerId: {customerId ?? "Unknown"}");
                    continue;
                }

                validEntries.Add(new UsageRequest
                {
                    CustomerId = customerId,
                    API_Calls = apiCallProp.GetDouble(),
                    Storage_GB = storageProp.GetDouble(),
                    Compute_Minutes = computeMinuteProp.GetDouble()
                });
            }

            return validEntries;
        }

    }
}
