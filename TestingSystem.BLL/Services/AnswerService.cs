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
    public class AnswerService
    {
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        public AnswerService()
        {
            _unitOfWorkFactory = new UnitOfWorkFactory();
        }

        public AnswerService(UnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public EntityOperationResult<AnswerDto> AddAnswer(AnswerDto answer)
        {
            var answerModel = answer.ToModel(); 
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                if(string.IsNullOrEmpty(answer.AnswerText))
                {
                    return EntityOperationResult<AnswerDto>.Failture("Answer must not be empty");
                }
                unitOfWork.Answer.AddAnswer(answerModel);
                try
                {
                    unitOfWork.SaveChanges();
                }
                catch(Exception ex)
                {
                    return EntityOperationResult<AnswerDto>.Failture(ex.Message);
                }
            }
            return EntityOperationResult<AnswerDto>.Success(answer);
        }

        public EntityOperationResult<bool> DeleteAnswer(int answerId)
        {
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                if(unitOfWork.Answer.GetAnswerById(answerId) == null)
                {
                    return EntityOperationResult<bool>.Failture("No answer with such Id");
                }
                unitOfWork.Answer.DeleteAnswer(answerId);
                try
                {
                    unitOfWork.SaveChanges();
                }
                catch (Exception ex)
                {
                    return EntityOperationResult<bool>.Failture(ex.Message);
                }
            }
            return EntityOperationResult<bool>.Success(true);
        }
    }
}
