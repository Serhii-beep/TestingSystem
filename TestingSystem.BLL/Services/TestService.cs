using System.Collections.Generic;
using TestingSystem.BLL.Dtos;
using TestingSystem.BLL.Mappers;
using TestingSystem.DAL.UnitOfWork;
using System.Linq;

namespace TestingSystem.BLL.Services
{
    public class TestService
    {
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        public TestService()
        {
            _unitOfWorkFactory = new UnitOfWorkFactory();
        }

        public TestService(UnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public EntityOperationResult<List<TestDto>> GetTests(int testSetId)
        {
            List<TestDto> result = new List<TestDto>();
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                if(unitOfWork.TestSet.GetTestSetById(testSetId) == null)
                {
                    return EntityOperationResult<List<TestDto>>.Failture("No test set with such Id");
                }
                result = unitOfWork.Test.GetAllTests().Where(t => t.TestSetId == testSetId).ToDtoRange();
                JoinTestWithQuestion(result);
                JoinTestWithAnswers(result);
            }
            return EntityOperationResult<List<TestDto>>.Success(result);
        }

        private void JoinTestWithQuestion(TestDto test)
        {
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var questions = unitOfWork.Question.GetAllQuestions();
                test.Question = questions.FirstOrDefault(q => q.TestId == test.Id).ToDto();
            }
        }

        private void JoinTestWithQuestion(IEnumerable<TestDto> tests)
        {
            foreach(var test in tests)
            {
                JoinTestWithQuestion(test);
            }
        }

        private void JoinTestWithAnswers(TestDto test)
        {
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var answers = unitOfWork.Answer.GetAllAnswers();
                test.Answers = answers.Where(a => a.TestId == test.Id).ToDtoRange();
            }
        }

        private void JoinTestWithAnswers(List<TestDto> tests)
        {
            foreach(var test in tests)
            {
                JoinTestWithAnswers(test);
            }
        }
    }
}
