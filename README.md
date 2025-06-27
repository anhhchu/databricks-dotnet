# Databricks .NET Integration Examples

This project demonstrates how to connect to Databricks from .NET applications using two different approaches:

1. **ODBC Connection** - Using the Simba Spark ODBC Driver
2. **REST API Connection** - Using Databricks SQL Statement Execution API

## Project Structure

```
dotnet_databricks/
├── odbc/                    # ODBC connection example
│   ├── OdbcDatabricks.cs   # Main ODBC implementation
│   ├── README.md           # Detailed ODBC setup instructions
│   └── dotnet_databricks.csproj
├── restapi/                # REST API connection example
│   ├── RestapiDatabricks.cs # Main REST API implementation
│   ├── README.md           # Detailed REST API setup instructions
│   └── dotnet_databricks.csproj
└── README.md               # This file
```

## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- A Databricks workspace
- Databricks personal access token
- For ODBC: Simba Spark ODBC Driver (see [odbc/README.md](odbc/README.md) for installation instructions)

## Quick Start

### Option 1: REST API Connection

The REST API approach is simpler to set up and doesn't require additional drivers:

1. Navigate to the REST API example:
   ```bash
   cd restapi
   ```

2. Create a `secrets.json` file with your Databricks token:
   ```json
   {
     "DatabricksToken": "<YOUR_DATABRICKS_PERSONAL_ACCESS_TOKEN>"
   }
   ```

3. Build and run:
   ```bash
   dotnet build
   dotnet run
   ```

### Option 2: ODBC Connection

The ODBC approach provides better performance for large datasets and supports more advanced SQL features:

1. Install the Simba Spark ODBC Driver (see [odbc/README.md](odbc/README.md))
2. Configure your ODBC DSN
3. Navigate to the ODBC example:
   ```bash
   cd odbc
   ```

4. Create a `secrets.json` file with your Databricks password:
   ```json
   {
     "DatabricksOdbcPassword": "<YOUR_DATABRICKS_PERSONAL_ACCESS_TOKEN>"
   }
   ```

5. Build and run:
   ```bash
   dotnet build
   dotnet run
   ```

## What Each Example Does

Both examples execute a sample query against the Databricks `samples.tpch.orders` table and retrieve the results:

- **REST API**: Prints results to console
- **ODBC**: Writes results to `query_results.txt` file

## Configuration

Before running either example, you'll need to update the connection parameters in the source code:

- **Databricks Host**: Replace with your workspace URL
- **Warehouse ID**: Replace with your SQL warehouse ID
- **Authentication**: Use your personal access token

## Dependencies

Both projects use the following NuGet packages:
- `Microsoft.Extensions.Configuration.Json` - For reading configuration from JSON files
- `System.Net.Http.Json` - For HTTP requests (REST API only)
- `System.Data.Odbc` - For ODBC connections (ODBC only)

## Documentation

- [ODBC Setup Guide](odbc/README.md) - Detailed instructions for ODBC driver installation and configuration
- [REST API Setup Guide](restapi/README.md) - Detailed instructions for REST API setup
- [Databricks ODBC Driver Documentation](https://docs.databricks.com/en/integrations/odbc/download.html)
- [Databricks SQL Statement Execution API](https://docs.databricks.com/aws/en/dev-tools/sql-execution-tutorial)

## Security Notes

- Never commit your `secrets.json` file to version control
- Use environment variables or secure configuration management in production
- Rotate your Databricks personal access tokens regularly

## License

This project is provided as example code for educational purposes.
