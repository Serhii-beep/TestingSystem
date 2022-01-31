using System.Collections.Generic;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Abstract
{
    public interface ITestCategoryRepository
    {
        IEnumerable<TestCategory> GetAllTestCategories();
        TestCategory GetTestCategoryById(int id);
        void AddTestCategory(TestCategory category);
        void UpdateTestCategory(TestCategory category);
        void DeleteTestCategory(int id);
    }
}
