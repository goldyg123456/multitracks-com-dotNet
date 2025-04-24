using Microsoft.EntityFrameworkCore;
using Api.MultiTracks.Application.Middleware;
using Api.MultiTracks.Infrastructure.Data;
using Api.MultiTracks.Application.Services;

namespace Api.MultiTracks.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<MultiTracksDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<MultiTracksRepository>();
            builder.Services.AddScoped<MultiTracksService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<ApiKeyMiddleware>();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
