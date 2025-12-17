using Gs_Contability.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gs_Contability.Data.EntityConfig
{
    public class PaymentMethodMigration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("PaymentMethod");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Description)
                   .IsRequired()
                   .HasMaxLength(50);



        }
    }
}
