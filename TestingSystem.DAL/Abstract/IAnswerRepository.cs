using System.Collections.Generic;
using TestingSystem.DAL.DbContexts;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Abstract
{
    public interface IAnswerRepository
    {
        IEnumerable<Answer> GetAllAnswers();
        Answer GetAnswerById(int id);
        void AddAnswer(Answer answer);
        void UpdateAnswer(Answer answer);
        void DeleteAnswer(int id);
    }
}
