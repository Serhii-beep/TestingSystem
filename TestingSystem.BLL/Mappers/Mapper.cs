using System.Collections.Generic;
using TestingSystem.BLL.Dtos;
using TestingSystem.DAL.Models;

namespace TestingSystem.BLL.Mappers
{
    public static class Mapper
    {
        public static List<TestCategoryDto> ToDtoRange(this IEnumerable<TestCategory> testCategoriesEntity)
        {
            List<TestCategoryDto> result = new List<TestCategoryDto>();
            foreach(var testCategory in testCategoriesEntity)
            {
                result.Add(new TestCategoryDto() { Id = testCategory.Id, Name = testCategory.Name });
            }
            return result;
        }

        public static List<TestLevelDto> ToDtoRange(this IEnumerable<TestLevel> testLevelsEntity)
        {
            List<TestLevelDto> result = new List<TestLevelDto>();
            foreach (var testLevel in testLevelsEntity)
            {
                result.Add(new TestLevelDto() { Id = testLevel.Id, DifficultyLevel = testLevel.DifficultyLevel });
            }
            return result;
        }

        public static List<TestSetDto> ToDtoRange(this IEnumerable<TestSet> testSetsEntity)
        {
            List<TestSetDto> result = new List<TestSetDto>();
            foreach(var testSet in testSetsEntity)
            {
                result.Add(new TestSetDto() { Id = testSet.Id, 
                    TestCategoryId = testSet.TestCategoryId, 
                    TestLevelId = testSet.TestLevelId,
                    Description = testSet.Description });
            }
            return result;
        }
    }
}
