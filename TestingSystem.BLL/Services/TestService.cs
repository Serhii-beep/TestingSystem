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

        public EntityOperationResult<List<TestReadDto>> GetTests(int testSetId)
        {
            List<TestReadDto> result = new List<TestReadDto>();
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                if(unitOfWork.TestSet.GetTestSetById(testSetId) == null)
                {
                    return EntityOperationResult<List<TestReadDto>>.Failture("No test set with such Id");
                }
                result = unitOfWork.Test.GetAllTests().Where(t => t.TestSetId == testSetId).ToDtoRange();
                JoinTestWithQuestion(result);
                JoinTestWithAnswers(result);
            }
            return EntityOperationResult<List<TestReadDto>>.Success(result);
        }

        public EntityOperationResult<bool> CheckAnswer(int testId, int answerId)
        {
            bool result = false;
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                if(unitOfWork.Test.GetTestById(testId) == null)
                {
                    return EntityOperationResult<bool>.Failture("No tes with such Id");
                }
                if(unitOfWork.Answer.GetAnswerById(answerId) == null)
                {
                    return EntityOperationResult<bool>.Failture("No answer with such Id");
                }
                result = unitOfWork.Test.GetTestById(testId).CorrectAnswerId == answerId;
            }
            return EntityOperationResult<bool>.Success(result);
        }

        private void JoinTestWithQuestion(TestReadDto test)
        {
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var questions = unitOfWork.Question.GetAllQuestions();
                test.Question = questions.FirstOrDefault(q => q.TestId == test.Id).ToDto();
            }
        }

        private void JoinTestWithQuestion(IEnumerable<TestReadDto> tests)
        {
            foreach(var test in tests)
            {
                JoinTestWithQuestion(test);
            }
        }

        private void JoinTestWithAnswers(TestReadDto test)
        {
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var answers = unitOfWork.Answer.GetAllAnswers();
                test.Answers = answers.Where(a => a.TestId == test.Id).ToDtoRange();
            }
        }

        private void JoinTestWithAnswers(List<TestReadDto> tests)
        {
            foreach(var test in tests)
            {
                JoinTestWithAnswers(test);
            }
        }
    }
}
