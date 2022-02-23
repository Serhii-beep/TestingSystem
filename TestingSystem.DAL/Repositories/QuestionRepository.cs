using System.Collections.Generic;
using TestingSystem.DAL.Abstract;
using TestingSystem.DAL.DbContexts;
using TestingSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            Question question = GetQuestionById(id);
            DeleteQuestion(question);
        }

        public void DeleteQuestion(Question question)
        {
            if(_context.Entry(question).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                _context.Questions.Attach(question);
            }
            _context.Questions.Remove(question);
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            return _context.Questions;
        }

        public Question GetQuestionById(int id)
        {
            return _context.Questions.AsNoTracking().FirstOrDefault(q => q.Id == id);
        }

        public void UpdateQuestion(Question question)
        {
            _context.Questions.Attach(question);
            _context.Entry(question).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
