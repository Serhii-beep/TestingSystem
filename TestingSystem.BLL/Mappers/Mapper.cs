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
            foreach (var testCategory in testCategoriesEntity)
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
            foreach (var testSet in testSetsEntity)
            {
                result.Add(new TestSetDto()
                {
                    Id = testSet.Id,
                    TestCategoryId = testSet.TestCategoryId,
                    TestLevelId = testSet.TestLevelId,
                    Description = testSet.Description
                });
            }
            return result;
        }

        public static List<TestDto> ToDtoRange(this IEnumerable<Test> testsEntity)
        {
            List<TestDto> result = new List<TestDto>();
            foreach (var test in testsEntity)
            {
                result.Add(new TestDto()
                {
                    Id = test.Id,
                    CorrectAnswerId = test.CorrectAnswerId,
                    TestSetId = test.TestSetId
                });
            }
            return result;
        }

        public static List<AnswerDto> ToDtoRange(this IEnumerable<Answer> answersEntity)
        {
            List<AnswerDto> result = new List<AnswerDto>();
            foreach (var answer in answersEntity)
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

        #region toDto
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

        public static TestCreateDto ToDto(this Test test)
        {
            return new TestCreateDto()
            { 
                Id = test.Id,
                CorrectAnswerId = test.CorrectAnswerId,
                TestSetId = test.TestSetId
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

        public static TestLevelDto toDto(this TestLevel testLevel)
        {
            return new TestLevelDto()
            {
                Id = testLevel.Id,
                DifficultyLevel = testLevel.DifficultyLevel
            };
        }

        public static TestCategoryDto toDto(this TestCategory testCategory)
        {
            return new TestCategoryDto()
            {
                Id = testCategory.Id,
                Name = testCategory.Name
            };
        }

        public static TestSetDto toDto(this TestSet testSet)
        {
            return new TestSetDto()
            {
                Id = testSet.Id,
                TestCategoryId = testSet.TestCategoryId,
                TestLevelId = testSet.TestLevelId,
                Description = testSet.Description
            };
        }
        #endregion

        #region toModel
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
        public static TestSet ToModel(this TestSetDto testSetDto)
        {
            return new TestSet()
            {
                Id = testSetDto.Id,
                Description = testSetDto.Description,
                TestLevelId = testSetDto.TestLevelId,
                TestCategoryId = testSetDto.TestCategoryId
            };
        }

        public static TestCategory ToModel(this TestCategoryDto testCategoryDto)
        {
            return new TestCategory()
            {
                Id = testCategoryDto.Id,
                Name = testCategoryDto.Name
            };
        }

        public static TestLevel ToModel(this TestLevelDto testLevelDto)
        {
            return new TestLevel()
            {
                Id = testLevelDto.Id,
                DifficultyLevel = testLevelDto.DifficultyLevel
            };
        }

        public static Answer ToModel(this AnswerDto answerDto)
        {
            return new Answer()
            {
                Id = answerDto.Id,
                AnswerText = answerDto.AnswerText,
                TestId = answerDto.TestId
            };
        }

        public static Question ToModel(this QuestionDto questionDto)
        {
            return new Question()
            {
                Id = questionDto.Id,
                QuestionText = questionDto.QuestionText,
                Points = questionDto.Points,
                TestId = questionDto.TestId
            };
        }

        public static Test ToModel(this TestCreateDto testDto)
        {
            return new Test()
            {
                Id = testDto.Id,
                CorrectAnswerId = testDto.CorrectAnswerId,
                TestSetId = testDto.TestSetId
            };
        }

        public static Test ToModel(this TestDto testDto)
        {
            return new Test()
            {
                Id = testDto.Id,
                TestSetId = testDto.TestSetId,
                CorrectAnswerId = testDto.CorrectAnswerId
            };
        }
        #endregion
    }
}
