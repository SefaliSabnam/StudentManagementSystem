using System.Data.SqlClient;

namespace StudentManagementSystem.Database
{
    internal class DatabaseConnection
    {
        public static string ConnectionString =
            @"Server=RONY\SQLEXPRESS;
              Database=StudentDB;
              Trusted_Connection=True;
              TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}