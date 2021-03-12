using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MRX.Master.Api.Extensions
{
    public static class ConfigurationExtension
    {
        public static string GetDefaultConnectionString(this IConfiguration configuration)
        {
            var connectionString = new SqlConnectionStringBuilder
            {
                ["Server"] = configuration["Database:Server"],
                ["Initial Catalog"] = configuration["Database:DB"],
                ["User ID"] = configuration["Database:Username"],
                ["Password"] = configuration["Database:Password"]
            };
            return connectionString.ConnectionString;
        }
    }
}
