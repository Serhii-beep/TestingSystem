using System.Collections.Generic;
using TestingSystem.DAL.Abstract;
using TestingSystem.DAL.DbContexts;
using TestingSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            Answer answer = GetAnswerById(id);
            DeleteAnswer(answer);
        }

        public void DeleteAnswer(Answer answer)
        {
            if(_context.Entry(answer).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                _context.Answers.Attach(answer);
            }
            _context.Answers.Remove(answer);
        }

        public IEnumerable<Answer> GetAllAnswers()
        {
            return _context.Answers;
        }

        public Answer GetAnswerById(int id)
        {
            return _context.Answers.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void UpdateAnswer(Answer answer)
        {
            _context.Attach(answer);
            _context.Entry(answer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
