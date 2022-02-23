using System.Collections.Generic;
using TestingSystem.DAL.Abstract;
using TestingSystem.DAL.DbContexts;
using TestingSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TestingSystem.DAL.Repositories
{
    public class TestCategoryRepository : ITestCategoryRepository
    {
        private readonly TestingSystemDbContext _context;

        public TestCategoryRepository(TestingSystemDbContext context)
        {
            _context = context;
        }

        public void AddTestCategory(TestCategory category)
        {
            _context.TestCategories.Add(category);
        }

        public void DeleteTestCategory(int id)
        {
            TestCategory testCategory = GetTestCategoryById(id);
            DeleteTestCategory(testCategory);
        }

        public void DeleteTestCategory(TestCategory testCategory)
        {
            if(_context.Entry(testCategory).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                _context.TestCategories.Attach(testCategory);
            }
            _context.TestCategories.Remove(testCategory);
        }

        public IEnumerable<TestCategory> GetAllTestCategories()
        {
            return _context.TestCategories;
        }

        public TestCategory GetTestCategoryById(int id)
        {
            return _context.TestCategories.AsNoTracking().FirstOrDefault(tc => tc.Id == id);
        }

        public void UpdateTestCategory(TestCategory category)
        {
            _context.TestCategories.Attach(category);
            _context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
