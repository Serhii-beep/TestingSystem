using System.Collections.Generic;
using TestingSystem.DAL.Abstract;
using TestingSystem.DAL.DbContexts;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly TestingSystemDbContext _context;

        public AnswerRepository(TestingSystemDbContext context)
        {
            _context = context;
        }

        public void AddAnswer(Answer answer)
        {
            _context.Answers.Add(answer);
        }

        public void DeleteAnswer(int id)
        {
            _context.Answers.Remove(GetAnswerById(id));
        }

        public IEnumerable<Answer> GetAllAnswers()
        {
            return _context.Answers;
        }

        public Answer GetAnswerById(int id)
        {
            return _context.Answers.Find(id);
        }

        public void UpdateAnswer(Answer answer)
        {
            _context.Answers.Update(answer);
        }
    }
}
