# Databricks REST API Example

## 1. Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- A Databricks workspace and a valid Databricks personal access token

## 2. Create the `secrets.json` file

Create a `secrets.json` file in the `restapi` directory with the following content:

```json
{
  "DatabricksToken": "<YOUR_DATABRICKS_PERSONAL_ACCESS_TOKEN>"
}
```

Replace `<YOUR_DATABRICKS_PERSONAL_ACCESS_TOKEN>` with your actual Databricks token.

## 3. Build and Run the Program

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
For more information on Databricks REST API, see the [Databricks SQL Statement Execution API documentation](https://docs.databricks.com/en/sql/api/sql-execution.html).
