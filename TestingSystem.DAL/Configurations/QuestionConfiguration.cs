using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Configurations
{
    class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(e => e.QuestionText).IsRequired();
            builder.Property(e => e.Points).IsRequired();
        }
    }
}
