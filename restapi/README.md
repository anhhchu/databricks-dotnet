# Databricks REST API Example

## 1. Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download)
- A Databricks workspace and a valid Databricks personal access token

## 2. Required NuGet Packages

Run `dotnet restore` to install packages listed in the csproj file.

## 3. Create the secrets.json file

Create a `secrets.json` file in the [appropriate directory](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-9.0&tabs=linux#how-the-secret-manager-tool-works) for your OS:

```json
{
  "DatabricksToken": "<YOUR_DATABRICKS_PERSONAL_ACCESS_TOKEN>"
}
```

Replace `<YOUR_DATABRICKS_PERSONAL_ACCESS_TOKEN>` with your actual Databricks token.

## 4. Update the appsettings.json file

Update `appsettings.json` with configs for your environment.

## 5. Build and Run the Program

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
