
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using Pizza.Application.features.auth;
using Pizza.Domain.Common;
using Pizza.Infrastructure.persistense;
using Pizza.Infrastructure.Services;

namespace Pizza.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<IRegister, RegisterService>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegistrationCommand).Assembly));
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<UserContext>(opts => opts.UseNpgsql(builder.Configuration.GetConnectionString("ApiDataBase")));

            var app = builder.Build();
           
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
           
            

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
