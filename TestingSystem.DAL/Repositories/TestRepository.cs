using System.Collections.Generic;
using TestingSystem.DAL.Abstract;
using TestingSystem.DAL.DbContexts;
using TestingSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            Test test = GetTestById(id);
            DeleteTest(test);
        }

        public void DeleteTest(Test test)
        {
            if(_context.Entry(test).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                _context.Tests.Attach(test);
            }
            _context.Tests.Remove(test);
        }

        public IEnumerable<Test> GetAllTests()
        {
            return _context.Tests;
        }

        public Test GetTestById(int id)
        {
            return _context.Tests.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public void UpdateTest(Test test)
        {
            _context.Tests.Attach(test);
            _context.Entry(test).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
