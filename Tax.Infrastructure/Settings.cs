using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using Tax.Core.Configuration;

namespace Tax.Infrastructure
{
    public class Settings : ISettings
    {
        public SqlServer SqlServer { get; private set; } 

        public Settings(string appsettingsbasePath, string environment)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(appsettingsbasePath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();


            SqlServer = new SqlServer();
            configuration.GetSection("SqlServer").Bind(SqlServer);
        }
    }
}
