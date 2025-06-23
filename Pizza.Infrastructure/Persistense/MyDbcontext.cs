using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;


namespace Pizza.Infrastructure.persistense
{
    //Контекст бази даних, який використовує IConfiguration для отримання рядка підключення
    public class MyDbcontext (IConfiguration configuration) : DbContext
    {
        //Створення контексту бази даних з використанням IConfiguration для отримання рядка підключення
        protected readonly IConfiguration _configuration = configuration;
        //Конструктор для передачі IConfiguration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Передача рядка підключення до PostgreSQL
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("ApiDataBase"));
        }
    }
}
