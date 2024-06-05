using ai_code_challenger.common;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;
using System.Security.Permissions;
using ai_code_challenger.common.Model;

namespace ai_code_challenger.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Account> Account { get; set; } = null!;
        public DbSet<Challenge> Challenge { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseModel).IsAssignableFrom(entityType.ClrType))
                {
                    var entity = modelBuilder.Entity(entityType.ClrType);
                    entity.Property<long>("Id").HasColumnName($"{entityType.ClrType.Name}Id");
                }
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
