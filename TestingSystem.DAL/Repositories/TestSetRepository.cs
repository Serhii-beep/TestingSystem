using System.Collections.Generic;
using TestingSystem.DAL.Abstract;
using TestingSystem.DAL.DbContexts;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Repositories
{
    public class TestSetRepository : ITestSetRepository
    {
        private readonly TestingSystemDbContext _context;

        public TestSetRepository(TestingSystemDbContext context)
        {
            _context = context;
        }
        public void AddTestSet(TestSet testSet)
        {
            _context.TestSets.Add(testSet);
        }

        public void DeleteTestSet(int id)
        {
            _context.TestSets.Remove(GetTestSetById(id));
        }

        public IEnumerable<TestSet> GetAllTestSets()
        {
            return _context.TestSets;
        }

        public TestSet GetTestSetById(int id)
        {
            return _context.TestSets.Find(id);
        }

        public void UpdateTestSet(TestSet testSet)
        {
            _context.TestSets.Update(testSet);
        }
    }
}
