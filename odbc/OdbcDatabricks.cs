using System;
using System.Data.Odbc;

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
                using (OdbcCommand command = new OdbcCommand("SELECT * FROM samples.tpch.orders LIMIT 10", connection))
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