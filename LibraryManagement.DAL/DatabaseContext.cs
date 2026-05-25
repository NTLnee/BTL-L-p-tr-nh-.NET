using System.Data;
using Microsoft.Data.SqlClient;

namespace LibraryManagement.DAL
{
    public class DatabaseContext : IDisposable
    {
        private SqlConnection _connection;

        public DatabaseContext()
        {
            _connection = ConnectionHelper.GetConnection();
        }

        public IDbConnection Connection
        {
            get
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
                return _connection;
            }
        }

        public void Dispose()
        {
            if (_connection.State == ConnectionState.Open)
                _connection.Close();
            _connection.Dispose();
        }
    }
}
