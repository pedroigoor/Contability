using Gs_Contability.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gs_Contability.Data.EntityConfig
{
    public class UserMigration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Username)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(u => u.Email)
                     .IsRequired()
                     .HasMaxLength(255);
            builder.HasIndex(p => p.Email).IsUnique();
            builder.Property(u => u.PasswordHash)
                        .IsRequired();

        }
    }
}
