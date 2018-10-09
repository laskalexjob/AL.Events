namespace AL.Events.DAL.Infrastructure.Core
{
    public interface IConnectionManager
    {
        string GetConnectionString(string connectionName);
    }
}
