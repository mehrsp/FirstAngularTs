using System.Configuration;
using System.Data.SqlClient;

 namespace Infra.Data
{
    public static class ConnectionFactory
    {
        public static SqlConnection Create(string connectionName)
        {
            var connectinString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            var connection = new SqlConnection(connectinString);
            return connection;
        }
    }
}
