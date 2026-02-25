using Npgsql;
using System.Data;

namespace SmartAttend.Application.Common.Inferfaces
{
    public interface IDapperConnectionFactory
    {
        IDbConnection CreateConnection();
        Task<NpgsqlConnection> CreateOpenConnectionAsync();
    }
}
