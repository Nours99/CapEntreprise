using Dal;
using Dal.Interface;
using Dal.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace CaveAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddDbContext<CellarContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WineCellarDB;Trusted_Connection=True")
            );
            builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            // Add repositories - injection dependance
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
