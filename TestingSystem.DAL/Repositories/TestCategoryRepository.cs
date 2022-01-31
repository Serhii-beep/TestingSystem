using System.Collections.Generic;
using TestingSystem.DAL.Abstract;
using TestingSystem.DAL.DbContexts;
using TestingSystem.DAL.Models;

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
            _context.TestCategories.Remove(GetTestCategoryById(id));
        }

        public IEnumerable<TestCategory> GetAllTestCategories()
        {
            return _context.TestCategories;
        }

        public TestCategory GetTestCategoryById(int id)
        {
            return _context.TestCategories.Find(id);
        }

        public void UpdateTestCategory(TestCategory category)
        {
            _context.TestCategories.Update(category);
        }
    }
}
