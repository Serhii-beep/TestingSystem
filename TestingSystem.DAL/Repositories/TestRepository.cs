using System.Collections.Generic;
using TestingSystem.DAL.Abstract;
using TestingSystem.DAL.DbContexts;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly TestingSystemDbContext _context;

        public TestRepository(TestingSystemDbContext context)
        {
            _context = context;
        }

        public void AddTest(Test test)
        {
            _context.Tests.Add(test);
        }

        public void DeleteTest(int id)
        {
            _context.Tests.Remove(GetTestById(id));
        }

        public IEnumerable<Test> GetAllTests()
        {
            return _context.Tests;
        }

        public Test GetTestById(int id)
        {
            return _context.Tests.Find(id);
        }

        public void UpdateTest(Test test)
        {
            _context.Tests.Update(test);
        }
    }
}
