using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.BLL.Dtos;
using TestingSystem.BLL.Mappers;
using TestingSystem.DAL.UnitOfWork;

namespace TestingSystem.BLL.Services
{
    public class QuestionService
    {
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        public QuestionService()
        {
            _unitOfWorkFactory = new UnitOfWorkFactory();
        }

        public QuestionService(UnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public EntityOperationResult<QuestionDto> AddQuestion(QuestionDto question)
        {
            var questionModel = question.ToModel();
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                if(string.IsNullOrEmpty(question.QuestionText))
                {
                    return EntityOperationResult<QuestionDto>.Failture("Question must not be empty");
                }
                if(question.Points <= 0)
                {
                    return EntityOperationResult<QuestionDto>.Failture("Points must be greater than 0");
                }
                unitOfWork.Question.AddQuestion(questionModel);
                try
                {
                    unitOfWork.SaveChanges();
                }
                catch(Exception ex)
                {
                    return EntityOperationResult<QuestionDto>.Failture(ex.Message);
                }
            }
            return EntityOperationResult<QuestionDto>.Success(question);
        }
    }
}
