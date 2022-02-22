using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TestingSystem.DAL.Abstract;
using TestingSystem.DAL.DbContexts;
using TestingSystem.DAL.Models;
using System.Linq;

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
            TestLevel testLevel = GetTestLevelById(id);
            DeleteTestLevel(testLevel);
        }

        public void DeleteTestLevel(TestLevel testLevel)
        {
            if(_context.Entry(testLevel).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                _context.TestLevels.Attach(testLevel);
            }
            _context.TestLevels.Remove(testLevel);
        }

        public IEnumerable<TestLevel> GetAllTestLevels()
        {
            return _context.TestLevels;
        }

        public TestLevel GetTestLevelById(int id)
        {
            return _context.TestLevels.AsNoTracking().FirstOrDefault(tl => tl.Id == id);
        }

        public void UpdateTestLevel(TestLevel testLevel)
        {
            if(_context.Entry(testLevel).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                _context.TestLevels.Attach(testLevel);
            }            
            _context.Entry(testLevel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
