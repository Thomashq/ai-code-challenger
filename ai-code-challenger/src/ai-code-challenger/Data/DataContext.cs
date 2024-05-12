using ai_code_challenger.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Permissions;

namespace ai_code_challenger.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Account> Account { get; set; }
        public DbSet<Challenge> Challenge { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            BaseModel.Configure(modelBuilder);
        }
    }
}
