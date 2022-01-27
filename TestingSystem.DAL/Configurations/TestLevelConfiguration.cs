using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Configurations
{
    class TestLevelConfiguration : IEntityTypeConfiguration<TestLevel>
    {
        public void Configure(EntityTypeBuilder<TestLevel> builder)
        {
            builder.Property(e => e.DifficultyLevel).IsRequired();
        }
    }
}
