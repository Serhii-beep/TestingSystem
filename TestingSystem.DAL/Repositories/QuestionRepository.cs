using System.Collections.Generic;
using TestingSystem.DAL.Abstract;
using TestingSystem.DAL.DbContexts;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly TestingSystemDbContext _context;

        public QuestionRepository(TestingSystemDbContext context)
        {
            _context = context;
        }

        public void AddQuestion(Question question)
        {
            _context.Questions.Add(question);
        }

        public void DeleteQuestion(int id)
        {
            _context.Questions.Remove(GetQuestionById(id));
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            return _context.Questions;
        }

        public Question GetQuestionById(int id)
        {
            return _context.Questions.Find(id);
        }

        public void UpdateQuestion(Question question)
        {
            _context.Questions.Update(question);
        }
    }
}
