using System.Collections.Generic;
using System.Data;

namespace AL.Events.DAL.Infrastructure.Factories
{
    public interface ISqlFactory
    {
        IDbCommand CreateDbCommand(string commandText,IDbConnection connection, CommandType commandType, IReadOnlyCollection<IDataParameter> parameters = null);
        IDbConnection CreateSqlConnection();
        IDataParameter CreateDbParameter(string parameterName, object parameterValue, DbType dbParameterType);
    }
}
