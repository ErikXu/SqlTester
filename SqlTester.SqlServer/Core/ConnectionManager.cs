using System;
using System.Data.SqlClient;

namespace SqlTester.SqlServer.Core
{
    public class ConnectionManager : IDisposable
    {
        private readonly SqlConnection _connection;

        public SqlConnection Connection
        {
            get { return _connection; }
        }

        private ConnectionManager()
        {
            _connection = new SqlConnection(DatabaseContext.ConnectionString);
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