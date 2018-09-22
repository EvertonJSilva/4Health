using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FourHealth.Data.Repositories
{
    internal class RepositoryBase
    {
        internal const string CONNECTIONSTRING_KEY = "ConnectionString";

        private IDbConnection connection;
        internal IDbConnection Connection
        {
            get
            {
                return connection;
            }

            set
            {
                connection = value;
            }
        }

        public RepositoryBase(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection(CONNECTIONSTRING_KEY);
            if (string.IsNullOrWhiteSpace(connectionString.Value))
                throw new ArgumentNullException("Connection string not found");
            Connection = new SqlConnection(connectionString.Value);
        }

        public IDbTransaction transaction { get; private set; }



        public void SetTransaction(IDbTransaction transaction)
        {
            this.transaction = transaction;
            this.connection = transaction.Connection;
        }

        internal void SetConnection(IDbConnection connection)
        {
            this.connection = connection;
            this.transaction = null;
        }
    }
}
