using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.AppSettings
{
    public class ConnectionString
    {
        private readonly string _connectionString;
        public ConnectionString(string connectionString)
        {
            _connectionString = connectionString;

        }
        public string GetConnectionString
        {
            get { return _connectionString; }
        }
    }
}
