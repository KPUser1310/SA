using Microsoft.Extensions.Configuration;
using Npgsql;


namespace SmartAttend.Infrastructure
{
    public class AppConfigurationsProvider
    {
        protected IConfiguration _configuration;
        public AppConfigurationsProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetAppDbConnectionString()
        {
            var connBuilder = new NpgsqlConnectionStringBuilder();

            if (!string.IsNullOrEmpty(_configuration.GetValue<string>("SmartAttend:ServerName")))
            {
                connBuilder.Host = _configuration.GetValue<string>("SmartAttend:ServerName");
            }
            if (!string.IsNullOrEmpty(_configuration.GetValue<string>("SmartAttend:Port")))
            {
                connBuilder.Port = _configuration.GetValue<int>("SmartAttend:Port");
            }

            if (!string.IsNullOrEmpty(_configuration.GetValue<string>("SmartAttend:DbName")))
            {
                connBuilder.Database = _configuration.GetValue<string>("SmartAttend:DbName");
            }

            if (!string.IsNullOrEmpty(_configuration.GetValue<string>("SmartAttend:PGUserName")))
            {
                connBuilder.Username = _configuration.GetValue<string>("SmartAttend:PGUserName");
            }

            if (!string.IsNullOrEmpty(_configuration.GetValue<string>("SmartAttend:PGPassword")))
            {
                connBuilder.Password = _configuration.GetValue<string>("SmartAttend:PGPassword");
            }

            return connBuilder.ConnectionString;
        }

    }
}
