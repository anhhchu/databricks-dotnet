using System;
using System.Data.Odbc;
using Microsoft.Extensions.Configuration;
using System.IO;

// CHOOSE OPTION BELOW TO RUN THE PROGRAM.
// 1. Use DSN connection through odbc.ini file
// 2. Use DSN-less connection through odbcinst.ini file

/* Option 1: Use DSN connection through odbc.ini file
public class DatabricksODBCConnector
{
    public void ExecuteQuery()
    {
        string dsn = "dsn=Databricks";
        using (var writer = new System.IO.StreamWriter("query_results.txt"))
        {
            using (OdbcConnection connection = new OdbcConnection(dsn))
            {
                connection.Open();
                using (OdbcCommand command = new OdbcCommand("SELECT * FROM samples.tpch.orders LIMIT 100000", connection))
                {
                    using (OdbcDataReader reader = command.ExecuteReader())
                    {
                        // Write header
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            writer.Write(reader.GetName(i));
                            if (i < reader.FieldCount - 1) writer.Write("\t");
                        }
                        writer.WriteLine();
                        // Write rows
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                writer.Write(reader.GetValue(i));
                                if (i < reader.FieldCount - 1) writer.Write("\t");
                            }
                            writer.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
*/

/* Option 2: Use DSN-less connection through odbcinst.ini file
- connect to your data store by providing your application with a connection string where the Driverproperty is set to the connector name specified in the odbcinst.ini file
- the connection string is a comma-separated list of key-value pairs.
- the key-value pairs are:
    - Driver: the connector name specified in the odbcinst.inifile
    - Host: the host of the data store
    - Port: the port of the data store
    - HTTPPath: the HTTP path of the data store
    - AuthMech: the authentication mechanism
*/

public class DatabricksODBCConnector
{
    public void ExecuteQuery()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets<Program>()
            .Build();

        // Configuration
        var baseUrl = config["DatabricksInstanceName"];
        var accessToken = config["DatabricksToken"];
        var warehouseId = config["WarehouseId"];

        if (string.IsNullOrEmpty(accessToken))
        {
            Console.WriteLine("DatabricksToken is not set in secrets.json");
            return;
        }

        var DSN = "Driver=Simba Spark ODBC Driver;Host="+baseUrl+";Port=443;HTTPPath=/sql/1.0/warehouses/"+warehouseId+";AuthMech=3;UID=token;PWD=" + accessToken + ";SSL=1;ThriftTransport=2";

        using (var writer = new System.IO.StreamWriter("query_results.txt"))
        {
            using (OdbcConnection connection = new OdbcConnection(DSN))
            {
                connection.Open();
                using (OdbcCommand command = new OdbcCommand("SELECT * FROM samples.tpch.orders LIMIT 100000", connection))
                {
                    using (OdbcDataReader reader = command.ExecuteReader())
                    {
                        // Write header
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            writer.Write(reader.GetName(i));
                            if (i < reader.FieldCount - 1) writer.Write("\t");
                        }
                        writer.WriteLine();
                        // Write rows
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                writer.Write(reader.GetValue(i));
                                if (i < reader.FieldCount - 1) writer.Write("\t");
                            }
                            writer.WriteLine();
                        }
                    }
                }
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        DatabricksODBCConnector connector = new DatabricksODBCConnector();
        connector.ExecuteQuery();
    }
}