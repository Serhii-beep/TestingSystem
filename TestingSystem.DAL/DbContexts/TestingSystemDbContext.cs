using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestingSystem.DAL.Configurations;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.DbContexts
{
    public partial class TestingSystemDbContext : DbContext
    {
        #region DbSets

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<TestCategory> TestCategories { get; set; }
        public virtual DbSet<TestLevel> TestLevels { get; set; }
        public virtual DbSet<TestSet> TestSets { get; set; }
        public virtual DbSet<User> Users { get; set; }

        #endregion

        internal AppConfiguration AppConfiguration { get; set; }

        public TestingSystemDbContext(DbContextOptions<TestingSystemDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ApplyingConfigurations

            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");
            modelBuilder.ApplyConfiguration(new AnswerConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new TestCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TestConfiguration());
            modelBuilder.ApplyConfiguration(new TestLevelConfiguration());
            modelBuilder.ApplyConfiguration(new TestSetConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            #endregion

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
