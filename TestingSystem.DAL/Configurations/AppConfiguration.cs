using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.DAL.Configurations
{
    class AppConfiguration
    {
        public string SqlServerConnectionString { get; }
        public AppConfiguration()
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            string pathToConnectionString = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "TestingSystem.PLL\\appsettings.json");
            configurationBuilder.AddJsonFile(pathToConnectionString, false);
            var configurationRoot = configurationBuilder.Build();
            var appSettings = configurationRoot.GetSection("ConnectionStrings:DefaultConnection");
            SqlServerConnectionString = appSettings.Value;
        }
    }
}
