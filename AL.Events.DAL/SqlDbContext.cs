using AL.Events.DAL.Infrastructure.Core.Implementations;
using System.Data;
using System.Data.SqlClient;

namespace AL.Events.DAL
{
    public class SqlDbContext
    {
        public SqlConnection GetConnection()
        {
            var connectionManager = new ConnectionManager();
            var connectionString = connectionManager.GetConnectionString(DbConstant.conStrName);
            var connection = new SqlConnection(connectionString);
            return connection;
        }

        public IDbCommand GetCommand(SqlConnection connection, string storedProcedure)
        {
            var command = new SqlCommand(storedProcedure, connection) { CommandType = CommandType.StoredProcedure };
            return command;
        }

        public DataTable CreateTable(string tableName)
        {
            var table = new DataTable(tableName);
            return table;
        }

        public DataTable FillInTable(DataTable table, IDbCommand command)
        {
            var adapter = new SqlDataAdapter((SqlCommand)command);
            adapter.Fill(table);
            return table;
        }
    }
}
