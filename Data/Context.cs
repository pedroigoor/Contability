
using Gs_Contability.Data.EntityConfig;
using Gs_Contability.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gs_Contability.Data
{
    public class Context : DbContext
    {
        public readonly IConfiguration _configuration;

    
        public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<User> Users => Set<User>();


        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_configuration.GetConnectionString("gs_contability"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new CategoryMigration());
            builder.ApplyConfiguration(new PaymentMethodMigration());
            builder.ApplyConfiguration(new UserMigration());
        }
    }
}
