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

        public static List<TestReadDto> ToDtoRange(this IEnumerable<Test> testsEntity)
        {
            List<TestReadDto> result = new List<TestReadDto>();
            foreach(var test in testsEntity)
            {
                result.Add(new TestReadDto()
                {
                    Id = test.Id,
                    TestSetId = test.TestSetId
                });
            }
            return result;
        }

        public static List<AnswerDto> ToDtoRange(this IEnumerable<Answer> answersEntity)
        {
            List<AnswerDto> result = new List<AnswerDto>();
            foreach(var answer in answersEntity)
            {
                result.Add(new AnswerDto()
                {
                    Id = answer.Id,
                    AnswerText = answer.AnswerText,
                    TestId = answer.TestId
                });
            }
            return result;
        }

        public static QuestionDto ToDto(this Question question)
        {
            return new QuestionDto()
            {
                Id = question.Id,
                TestId = question.TestId,
                QuestionText = question.QuestionText,
                Points = question.Points
            };
        }

        public static UserDto ToDto(this User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                Role = user.Role
            };
        }

        public static User ToModel(this UserDto userDto)
        {
            return new User()
            {
                Id = userDto.Id,
                UserName = userDto.UserName,
                Password = userDto.Password,
                Role = userDto.Role
            };
        }
    }
}
