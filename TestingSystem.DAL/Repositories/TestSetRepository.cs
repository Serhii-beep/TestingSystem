using System.Collections.Generic;
using TestingSystem.DAL.Abstract;
using TestingSystem.DAL.DbContexts;
using TestingSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            TestSet testSet = GetTestSetById(id);
            DeleteTestSet(testSet);
        }

        public void DeleteTestSet(TestSet testSet)
        {
            if(_context.Entry(testSet).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                _context.TestSets.Attach(testSet);
            }
            _context.TestSets.Remove(testSet);
        }

        public IEnumerable<TestSet> GetAllTestSets()
        {
            return _context.TestSets;
        }

        public TestSet GetTestSetById(int id)
        {
            return _context.TestSets.AsNoTracking().FirstOrDefault(ts => ts.Id == id);
        }

        public void UpdateTestSet(TestSet testSet)
        {
            _context.TestSets.Attach(testSet);
            _context.Entry(testSet).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
