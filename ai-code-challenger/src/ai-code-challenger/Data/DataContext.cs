using ai_code_challenger.common;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;
using System.Security.Permissions;

namespace ai_code_challenger.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Account> Account { get; set; } = null!;
        public DbSet<Challenge> Challenge { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            BaseModel.Configure(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetCallingAssembly());
        }
    }
}
