using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TestingSystem.DAL.Configurations;

namespace TestingSystem.DAL.DbContexts
{
    public class DbContextFactory : IDesignTimeDbContextFactory<TestingSystemDbContext>
    {
        public TestingSystemDbContext CreateDbContext(string[] args)
        {
            AppConfiguration appConfiguration = new AppConfiguration();
            var optionsBuilder = new DbContextOptionsBuilder<TestingSystemDbContext>();
            optionsBuilder.UseSqlServer(appConfiguration.SqlServerConnectionString);
            return new TestingSystemDbContext(optionsBuilder.Options);
        }
    }
}
