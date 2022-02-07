using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Configurations
{
    class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.Property(e => e.CorrectAnswerId).IsRequired();
            builder.Property(e => e.TestSetId).IsRequired();


            builder.HasOne(t => t.TestSet)
                .WithMany(ts => ts.Tests)
                .HasForeignKey(t => t.TestSetId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Tests_TestSets");

        }
    }
}
