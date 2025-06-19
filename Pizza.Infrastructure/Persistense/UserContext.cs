using Microsoft.EntityFrameworkCore;
using Pizza.Domain.Entity;
using System.Reflection;


namespace Pizza.Infrastructure.persistense
{
    public class UserContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet <User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
