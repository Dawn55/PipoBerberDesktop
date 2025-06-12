using Microsoft.Data.SqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipoBerberDesktop.Helpers
{
    public class DatabaseHelper
    {
        public static IDbConnection GetConnection()
        {

            string dbPath = Path.Combine(Application.StartupPath, "veritabani.db");
            string connectionString = $"Data Source={dbPath};Version=3;";

            return new SQLiteConnection(connectionString);
        }
        public static string GetConnectionString()
        {
            string dbPath = Path.Combine(Application.StartupPath, "veritabani.db");
            string connectionString = $"Data Source={dbPath};Version=3;";
            return connectionString;
;
        }
    }
}
