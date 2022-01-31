using System.Collections.Generic;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Abstract
{
    public interface ITestRepository
    {
        IEnumerable<Test> GetAllTests();
        Test GetTestById(int id);
        void AddTest(Test test);
        void UpdateTest(Test test);
        void DeleteTest(int id);
    }
}
