using Microsoft.Extensions.Configuration;
using Npgsql;
using SmartAttend.Application.Common.Inferfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Infrastructure.Persistence
{
    public class DapperContext : IDapperConnectionFactory
    {
        private readonly string _connection;
        public DapperContext(IConfiguration configuration)
        {
            var configProvider = new AppConfigurationsProvider(configuration);
            _connection = configProvider.GetAppDbConnectionString() ?? throw new ArgumentNullException(nameof(configuration)); ;
        }
        public IDbConnection CreateConnection() => new NpgsqlConnection(_connection);

        public async Task<NpgsqlConnection> CreateOpenConnectionAsync()
        {
            var connection = new NpgsqlConnection(_connection);
            await connection.OpenAsync();
            return connection;
        }
    }
}
