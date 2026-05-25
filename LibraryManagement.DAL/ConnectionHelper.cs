using Microsoft.Data.SqlClient;

namespace LibraryManagement.DAL
{
    public static class ConnectionHelper
    {
        // Sửa thông tin server/database cho đúng máy của nhóm
        private static readonly string _connectionString =
            "Server=.;Database=LibraryManagement;Trusted_Connection=True;" +
            "TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public static string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
