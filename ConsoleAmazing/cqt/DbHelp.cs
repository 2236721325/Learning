using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqt
{
    public class DBHelp
    {
        public static string? sqliteConnection;
        public static async Task QueryAsync()
        {
            using (IDbConnection cnn = new SqliteConnection())
            {
                cnn.Open();
                cnn.Query<dynamic>()
            }
        }
    }
}
