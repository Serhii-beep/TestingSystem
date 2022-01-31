using System.Collections.Generic;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Abstract
{
    public interface ITestLevelRepository
    {
        IEnumerable<TestLevel> GetAllTestLevels();
        TestLevel GetTestLevelById(int id);
        void AddTestLevel(TestLevel testLevel);
        void UpdateTestLevel(TestLevel testLevel);
        void DeleteTestLevel(int id);
    }
}
