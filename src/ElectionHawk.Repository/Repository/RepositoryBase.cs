using ElectionHawk.Common.AppSettings;
using ElectionHawk.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Repository
{
    public class RepositoryBase : IRepositoryBase
    {
        private ConnectionString _connectionString;

        public RepositoryBase(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public string GetConnectionString
        {
            get { return _connectionString.GetConnectionString; }
        }
    }
}
