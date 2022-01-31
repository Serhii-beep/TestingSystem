using System.Collections.Generic;
using TestingSystem.DAL.Abstract;
using TestingSystem.DAL.DbContexts;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Repositories
{
    public class TestLevelRepository : ITestLevelRepository
    {
        private readonly TestingSystemDbContext _context;

        public TestLevelRepository(TestingSystemDbContext context)
        {
            _context = context;
        }

        public void AddTestLevel(TestLevel testLevel)
        {
            _context.TestLevels.Add(testLevel);
        }

        public void DeleteTestLevel(int id)
        {
            _context.TestLevels.Remove(GetTestLevelById(id));
        }

        public IEnumerable<TestLevel> GetAllTestLevels()
        {
            return _context.TestLevels;
        }

        public TestLevel GetTestLevelById(int id)
        {
            return _context.TestLevels.Find(id);
        }

        public void UpdateTestLevel(TestLevel testLevel)
        {
            _context.TestLevels.Update(testLevel);
        }
    }
}
