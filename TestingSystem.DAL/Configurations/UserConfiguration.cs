using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.UserName).IsRequired().HasColumnType("nvarchar(20)").HasMaxLength(20);
            builder.Property(e => e.Password).IsRequired().HasColumnType("nvarchar(20)").HasMaxLength(20);
            builder.Property(e => e.Role).IsRequired().HasColumnType("nvarchar(15)");
        }
    }
}
