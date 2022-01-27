using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Configurations
{
    class TestSetConfiguration : IEntityTypeConfiguration<TestSet>
    {
        public void Configure(EntityTypeBuilder<TestSet> builder)
        {
            builder.HasOne(ts => ts.TestCategory)
                .WithMany(tc => tc.TestSets)
                .HasForeignKey(ts => ts.TestCategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TestSets_TestCategories");

            builder.HasOne(ts => ts.TestLevel)
                .WithMany(tl => tl.TestSets)
                .HasForeignKey(ts => ts.TestLevelId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TestSets_TestLevels");
        }
    }
}
