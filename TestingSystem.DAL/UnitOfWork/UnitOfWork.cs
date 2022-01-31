using System;
using TestingSystem.DAL.Abstract;
using TestingSystem.DAL.DbContexts;
using TestingSystem.DAL.Repositories;

namespace TestingSystem.DAL.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private readonly TestingSystemDbContext _context;
        private bool _disposed = false;

        public IAnswerRepository Answer { get; }
        public IQuestionRepository Question { get; }
        public ITestRepository Test { get; }
        public ITestCategoryRepository TestCategory { get; }
        public ITestLevelRepository TestLevel { get; }
        public ITestSetRepository TestSet { get; }
        public UnitOfWork(TestingSystemDbContext context)
        {
            _context = context;
            Answer = new AnswerRepository(_context);
            Question = new QuestionRepository(_context);
            Test = new TestRepository(_context);
            TestCategory = new TestCategoryRepository(_context);
            TestLevel = new TestLevelRepository(_context);
            TestSet = new TestSetRepository(_context);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if(disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
