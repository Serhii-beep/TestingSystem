using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Configurations
{
    class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.Property(e => e.AnswerText).IsRequired();

            builder.HasOne(a => a.Test)
                .WithMany(t => t.Answers)
                .HasForeignKey(a => a.TestId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Answers_Tests");
        }
    }
}
