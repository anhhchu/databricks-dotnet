# Databricks REST API Example

## 1. Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download)
- A Databricks workspace and a valid Databricks personal access token

## 2. Required NuGet Packages

Run `dotnet restore` to install packages listed in the csproj file.

## 3. Configure appsettings.json and user secrets

Update the `appsettings.json` file in your project directory with DatabricksInstanceName and WarehouseId

```json
{
    "DatabricksInstanceName": "xxxxx.cloud.databricks.com",
    "WarehouseId": "xxxx"
}
```

Create dotnet user secrets to store DatabricksToken as environment variable to authenticate and authorize user to query Databricks warehouse:

1. Initialize user secrets for your project by running the following command. This will add a UserSecretsId to your project's .csproj file:

```
dotnet user-secrets init
```

2. Set the user secrets

```
dotnet user-secrets set "DatabricksToken" "your-databricks-access-token"
```

3. You can also list all the secrets with below command

```
dotnet user-secrets list
```

4. To use user secrets in code, specify AddUserSecrets in the main program config

```
IConfigurationRoot config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .AddUserSecrets<Program>()
            .Build();
```


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
