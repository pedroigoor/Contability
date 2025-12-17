using Gs_Contability.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gs_Contability.Data.EntityConfig
{
    public class CategoryMigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Description)
                   .IsRequired()
                   .HasMaxLength(50);



        }
    }
}
