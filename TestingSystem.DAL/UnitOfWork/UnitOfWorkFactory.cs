using TestingSystem.DAL.DbContexts;

namespace TestingSystem.DAL.UnitOfWork
{
    public class UnitOfWorkFactory
    {
        public UnitOfWork CreateUnitOfWork()
        {
            DbContextFactory dbContextFactory = new DbContextFactory();
            return new UnitOfWork(dbContextFactory.CreateDbContext(null));
        }
    }
}
