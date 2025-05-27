// See https://aka.ms/new-console-template for more information
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Databricks.Dotnet.Demo
{
    class RestapiDatabricks
    {
        static async Task Main(string[] args)
        {
            var databricksHost = "https://e2-demo-field-eng.cloud.databricks.com";
            var sqlEndpoint = "/api/2.0/sql/statements/";

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("secrets.json", optional: false, reloadOnChange: true)
                .Build();

            var token = config["DatabricksToken"];

            using var client = new HttpClient();
            client.BaseAddress = new Uri(databricksHost);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var requestBody = new
            {
                statement = "SELECT * FROM samples.tpch.orders LIMIT 10",
                warehouse_id = "30d6e63b35f828c5"
            };

            var response = await client.PostAsJsonAsync(sqlEndpoint, requestBody);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
    }
} 