using Microsoft.EntityFrameworkCore;

namespace paymayAPI.Persistence.Context
{
    public class paymayAPIDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public paymayAPIDbContext(DbContextOptions<paymayAPIDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}