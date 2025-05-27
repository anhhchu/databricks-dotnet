# Databricks REST API Example

## 1. Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- A Databricks workspace and a valid Databricks personal access token

## 2. Required NuGet Packages

Install the following NuGet packages in the `restapi` directory (if not already present in the project file):

```sh
 dotnet add package Microsoft.Data.Analysis
 dotnet add package Microsoft.Extensions.Configuration.Json
 dotnet add package System.Net.Http.Json
```

## 3. Create the `secrets.json` file

Create a `secrets.json` file in the `restapi` directory with the following content:

```json
{
  "DatabricksToken": "<YOUR_DATABRICKS_PERSONAL_ACCESS_TOKEN>"
}
```

Replace `<YOUR_DATABRICKS_PERSONAL_ACCESS_TOKEN>` with your actual Databricks token.

## 4. Build and Run the Program

1. Open a terminal and navigate to the `restapi` directory:
   ```sh
   cd restapi
   ```
2. Restore dependencies and build the project:
   ```sh
   dotnet build
   ```
3. Run the program:
   ```sh
   dotnet run
   ```

The program will execute a sample query against your Databricks workspace using the REST API and print the results to the console.

---
For more information on Databricks REST API, see the [Databricks SQL Statement Execution API documentation](https://docs.databricks.com/aws/en/dev-tools/sql-execution-tutorial).
