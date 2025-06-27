# Databricks ODBC Example

## 1. Install the Databricks ODBC Driver

### macOS
1. Download the Databricks ODBC driver for Mac from the [official Databricks ODBC Driver download page](https://www.databricks.com/spark/odbc-drivers-download).
2. Extract the downloaded `.zip` file.
3. Double-click the extracted `.dmg` file and follow the on-screen instructions to install the driver (it will be installed in `/Library/simba/spark`).

### Windows
1. Download the Databricks ODBC driver for Windows from the [official Databricks ODBC Driver download page](https://www.databricks.com/spark/odbc-drivers-download).
2. Extract the downloaded `.zip` file.
3. Double-click the extracted `.msi` file and follow the on-screen instructions to install the driver (it will be installed in `C:\Program Files\Simba Spark ODBC Driver`).

### Linux
1. Download the appropriate `.rpm` or `.deb` package from the [official Databricks ODBC Driver download page](https://www.databricks.com/spark/odbc-drivers-download).
2. Extract the downloaded `.zip` file.
3. Install the driver using your package manager:
   - For RPM-based systems:
     ```sh
     sudo yum --nogpgcheck localinstall simbaspark_<version>.rpm
     ```
   - For DEB-based systems:
     ```sh
     sudo dpkg -i simbaspark_<version>.deb
     ```
   The driver will be installed in `/opt/simba/spark`.


## 2. Configure the ODBC DSN
Refer to [Databricks ODBC documentation](https://docs.databricks.com/aws/en/assets/files/Simba-Apache-Spark-ODBC-Connector-Install-and-Configuration-Guide-231e7e0f44e5c1e164d8ffe590de337e.pdf) for details on DSN configuration, including authentication and server settings.

Below examples are applicable to MacOS, you can choose either option (DSN or DSN-less) to run the program:

1. Use DSN connection through odbc.ini file

After installation, configure a DSN named `Databricks` using the ODBC Administrator (macOS/Windows) or by editing your `odbc.ini` file (Linux/macOS) which looks similar to below: 

```
[ODBC Data Sources]
Databricks = Simba Spark ODBC Driver

[Databricks]
Driver   = /Library/simba/spark/lib/libsparkodbc_sb64-universal.dylib
Host     = xxxxxxxxx.databricks.com
Port     = 443
HTTPPath = /sql/1.0/warehouses/xxxxxxxxxxxxxxx
AuthMech = 3
UID      = token
PWD      = dapixxxxxxxx
SSL      = 1
ThriftTransport = 2
```

2. Or Use DSN-less connection through odbcinst.ini file

For example, provide below setting to odbcinst.ini file

```
[ODBC Drivers]
Simba Spark ODBC Driver=Installed

[Simba Spark ODBC Driver]
Description=Simba Spark ODBC Driver DSN
Driver=/Library/simba/spark/lib/libsparkodbc_sb64-universal.dylib
```

Then specify your DSN connection string in the program. The connection string is a comma-separated list of key-value pairs. The required key-value pairs are:
   - Driver: the connector name specified in the odbcinst.inifile
   - Host: the host of the data store
   - Port: the port of the data store
   - HTTPPath: the HTTP path of the data store
   - AuthMech: the authentication mechanism

## 2.1. Configure appsettings.json and user secrets

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

## 2.2. Specify the dsn for the ODBC connection in OdbcDatabricks.cs file

```
string dsn = "Driver=Simba Spark ODBC Driver;Host="+baseUrl+";Port=443;HTTPPath=/sql/1.0/warehouses/"+warehouseId+";AuthMech=3;UID=token;PWD=" + accessToken + ";SSL=1;ThriftTransport=2";
```
## 3. Required NuGet Packages

Run `dotnet restore` to install packages listed in the csproj file.

## 4. Build and Run the Program

1. Open a terminal and navigate to the `odbc` directory:
   ```sh
   cd odbc
   ```
2. Restore dependencies and build the project:
   ```sh
   dotnet build
   ```
3. Run the program:
   ```sh
   dotnet run
   ```

The program will execute a sample query against your Databricks workspace and write the results to `query_results.txt`.

---
For more information, see the [Databricks ODBC Driver Guide](https://docs.databricks.com/en/integrations/odbc/download.html).
