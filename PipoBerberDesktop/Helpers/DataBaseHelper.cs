using Microsoft.Data.SqlClient;
using Npgsql;
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
            
            return new NpgsqlConnection("Host=aws-0-eu-central-1.pooler.supabase.com;Port=6543;Username=postgres.eryvmyaotsqfapjgawqh;Password=554822597ys;Database=postgres;Pooling=true");
        }
        public static string GetConnectionString()
        {
            return "Host=aws-0-eu-central-1.pooler.supabase.com;Port=6543;Username=postgres.eryvmyaotsqfapjgawqh;Password=554822597ys;Database=postgres;Pooling=true"
;
        }
    }
}
