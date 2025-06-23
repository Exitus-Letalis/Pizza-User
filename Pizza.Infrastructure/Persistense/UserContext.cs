using Microsoft.EntityFrameworkCore;
using Pizza.Domain.Entity;
using System.Reflection;


namespace Pizza.Infrastructure.persistense
{
    // Контекст бази даних для користувачів, який використовує DbContextOptions для налаштування
    public class UserContext(DbContextOptions options) : DbContext(options)
    {
        // Контекст бази даних для користувачів
        public DbSet <User> User { get; set; }
        // Передача параметрів конфігурації до бази даних
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // формування моделі бази даних
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
