
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace ApiNetCore7.Helpers
{
    public class ConexionHelper
    {

        private readonly IConfiguration _configuration;

        public ConexionHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetOracleConnectionString()
        {
            string connectionString = _configuration.GetConnectionString("oracle");
            return connectionString;
        }

        public static Task<IEnumerable<T>> FDapperExecuteQuery<T>(string sqlQuery, Dictionary<string, object> parameters = null) where T : new()
        {
            using (OracleConnection connection = new OracleConnection(""))
            {
                connection.Open();

                if (parameters != null)
                {
                    return connection.QueryAsync<T>(sqlQuery, parameters);
                }
                else
                {
                    return connection.QueryAsync<T>(sqlQuery);
                }
            }
        }
    }
}
