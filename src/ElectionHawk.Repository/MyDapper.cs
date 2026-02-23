using System;
using System.Data;
using System.Data.SqlClient;

namespace ElectionHawk.Repository
{
    public static class MyDapper
    {

        public static IDbConnection CreateConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        public static SqlConnection CreateSqlConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

    }
}
