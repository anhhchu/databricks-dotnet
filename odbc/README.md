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

After installation, configure a DSN named `Databricks` using the ODBC Administrator (macOS/Windows) or by editing your `odbc.ini` file (Linux/macOS). Refer to the [Databricks ODBC documentation](https://docs.databricks.com/aws/en/assets/files/Simba-Apache-Spark-ODBC-Connector-Install-and-Configuration-Guide-231e7e0f44e5c1e164d8ffe590de337e.pdf) for details on DSN configuration, including authentication and server settings.

## 3. Build and Run the Program

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
