using AL.Events.DAL.Infrastructure.Core;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AL.Events.DAL.Infrastructure.Factories.Implementations
{
    internal class SqlFactory : ISqlFactory
    {
        private const string ConnectionName = DbConstant.conStrName;
        private readonly IConnectionManager _connectionManager;
        private readonly string _connectionString;

        public SqlFactory(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
            _connectionString = _connectionManager.GetConnectionString(ConnectionName);
        }

        public IDbCommand CreateDbCommand(string commandText,IDbConnection connection, CommandType commandType, IReadOnlyCollection<IDataParameter> parameters = null)
        {
            IDbCommand command;

            if (parameters != null)
            {
                command = new SqlCommand(commandText, connection as SqlConnection) { CommandType = CommandType.StoredProcedure };

                foreach (var item in parameters)
                {
                    command.Parameters.Add(item);
                }
            }
            else
            {
                command = new SqlCommand(commandText, connection as SqlConnection) { CommandType = CommandType.StoredProcedure };
            }

            return command;
        }

        public IDbConnection CreateSqlConnection()
        {
            var sqlConnection = new SqlConnection(_connectionString);

            return sqlConnection;
        }

        public IDataParameter CreateDbParameter(string parameterName, object parameterValue, DbType dbParameterType)
        {
            parameterName = parameterName.StartsWith("@") ? parameterName : "@" + parameterName;

            var parameter = new SqlParameter()
            {
                DbType = dbParameterType,
                ParameterName = parameterName,
                Value = parameterValue
            };

            return parameter;
        }
    }
}
