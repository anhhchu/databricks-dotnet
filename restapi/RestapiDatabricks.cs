using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

class Program
{
    static readonly HttpClient client = new HttpClient();

    static async Task Main()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .AddUserSecrets<Program>()
            .Build();

        try
        {
            // Configuration
            var baseUrl = $"https://{config["DatabricksInstanceName"]}/api/2.0/sql/statements";
            var accessToken = config["DatabricksToken"];
            var warehouseId = config["WarehouseId"];

            // Build JSON payload with parameters
            var payload = new
            {
                warehouse_id = warehouseId,
                catalog = "tpcds",
                schema = "sf_1000",
                statement = "select * from store_sales limit :row_limit",
                timeout_seconds = 600,
                format = "JSON_ARRAY",
                parameters = new[]
                {
                    new { name = "row_limit", value = "10", type = "INT" }
                }
            };

            // Serialize to JSON
            var jsonBody = JsonSerializer.Serialize(payload);

            // Configure request
            var request = new HttpRequestMessage(HttpMethod.Post, baseUrl)
            {
                Content = new StringContent(jsonBody, Encoding.UTF8, "application/json")
            };
            request.Headers.Add("Authorization", $"Bearer {accessToken}");

            // Execute request
            var response = await client.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();

            // Handle response
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success! Response:");
                Console.WriteLine(responseBody);
            }
            else
            {
                Console.WriteLine($"Error {response.StatusCode}: {responseBody}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}