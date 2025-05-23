using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipoBerberDesktop.Helpers
{
    public class DatabaseHelper
    {
        public static IDbConnection GetConnection()
        {
            
            return new SqlConnection("Server=DESKTOP-TD4GF4B\\SQLEXPRESS;Database=PipoBarberDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public static string GetConnectionString()
        {
            return "Server=DESKTOP-TD4GF4B\\SQLEXPRESS;Database=PipoBarberDb;Trusted_Connection=True;TrustServerCertificate=True;";
        }
    }
}
