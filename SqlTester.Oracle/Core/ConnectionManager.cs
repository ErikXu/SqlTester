using System;
using Oracle.ManagedDataAccess.Client;

namespace SqlTester.Oracle.Core
{
    public class ConnectionManager : IDisposable
    {
        private readonly OracleConnection _connection;

        public OracleConnection Connection
        {
            get { return _connection; }
        }

        private ConnectionManager()
        {
            _connection = new OracleConnection(DatabaseContext.ConnectionString);
            _connection.Open();
        }

        public static ConnectionManager GetManager()
        {
            return new ConnectionManager();
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}