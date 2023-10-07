using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace ApiNetCore7.Helpers
{


    public class OracleDbManager
    {

        IConfiguration configuration;
        public OracleDbManager(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("ConnectionStrings")["oracle"];
            IDbConnection connection = new OracleConnection(connectionString);
            connection.Open();
            return connection;
        }

        public string GetConnectionString()
        {
            string connectionString = configuration.GetSection("ConnectionStrings")["oracle"];
            return connectionString;
        }

        public Task<IEnumerable<T>> DapperExecuteQuery<T>(string sqlQuery, Dictionary<string, object> parameters = null) where T : new()
        {
            using (OracleConnection connection = new OracleConnection(GetConnectionString()))
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

        public IDbTransaction BeginTransaction(IDbConnection connection)
        {
            if (connection.State == ConnectionState.Open)
            {
                IDbTransaction transaction = connection.BeginTransaction();
                return transaction;
            }
            else
            {
                throw new InvalidOperationException("La conexión no está abierta.");
            }
        }

        public void CommitTransaction(IDbTransaction transaction)
        {
            if (transaction != null)
            {
                transaction.Commit();
                transaction.Connection.Close();
            }
        }

        public void RollbackTransaction(IDbTransaction transaction)
        {
            if (transaction != null)
            {
                transaction.Rollback();
                transaction.Connection.Close();
            }
        }
    }

}
