using TestingSystem.DAL.Models;
using System.Collections.Generic;

namespace TestingSystem.DAL.Abstract
{
    public interface ITestSetRepository
    {
        IEnumerable<TestSet> GetAllTestSets();
        TestSet GetTestSetById(int id);
        void AddTestSet(TestSet testSet);
        void UpdateTestSet(TestSet testSet);
        void DeleteTestSet(int id);
    }
}
