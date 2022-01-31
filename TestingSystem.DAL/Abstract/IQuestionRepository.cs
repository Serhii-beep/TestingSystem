using System.Collections.Generic;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Abstract
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetAllQuestions();
        Question GetQuestionById(int id);
        void AddQuestion(Question question);
        void UpdateQuestion(Question question);
        void DeleteQuestion(int id);
    }
}
