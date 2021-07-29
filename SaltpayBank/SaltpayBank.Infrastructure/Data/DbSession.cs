using System;
using System.Data;
using System.Data.SqlClient;

namespace SaltpayBank.Infrastructure.Data
{
    public sealed class DbSession : IDisposable
    {
        private Guid _id;
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DbSession(string connectionString)
        {
            _id = Guid.NewGuid();
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
