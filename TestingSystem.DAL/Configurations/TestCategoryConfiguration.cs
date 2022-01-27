using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Configurations
{
    class TestCategoryConfiguration : IEntityTypeConfiguration<TestCategory>
    {
        public void Configure(EntityTypeBuilder<TestCategory> builder)
        {
            builder.Property(e => e.Name).IsRequired();
        }
    }
}
