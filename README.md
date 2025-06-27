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


## What Each Example Does

Both examples execute a sample query against the Databricks `samples.tpch.orders` table (available in most Databricks workspaces) and retrieve the results:

- **REST API**: Prints results to console
- **ODBC**: Writes results to `query_results.txt` file


## Documentation

- [ODBC Setup Guide](odbc/README.md) - Detailed instructions for ODBC driver installation and configuration
- [REST API Setup Guide](restapi/README.md) - Detailed instructions for REST API setup
- [Databricks ODBC Driver Documentation](https://docs.databricks.com/en/integrations/odbc/download.html)
- [Databricks SQL Statement Execution API](https://docs.databricks.com/aws/en/dev-tools/sql-execution-tutorial)

## Security Notes

- Use environment variables or secure configuration management in production
- Rotate your Databricks personal access tokens regularly

## License

This project is provided as example code for educational purposes.
