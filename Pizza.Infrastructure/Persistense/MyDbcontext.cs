using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;


namespace Pizza.Infrastructure.persistense
{
    public class MyDbcontext (IConfiguration configuration) : DbContext
    {
        protected readonly IConfiguration _configuration = configuration;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("ApiDataBase"));
        }
    }
}
