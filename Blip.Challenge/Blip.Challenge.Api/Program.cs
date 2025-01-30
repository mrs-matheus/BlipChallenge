
using Blip.Challenge.Api.Configs;

namespace Blip.Challenge.Api
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

            //Dependency Injections
            ConfigIoC.AddDependencyInjection(builder.Services, builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //railway
            app.UseHttpsRedirection();
            if (builder.Environment.IsProduction() && builder.Configuration.GetValue<int?>("PORT") is not null)
                builder.WebHost.UseUrls($"http://*:{builder.Configuration.GetValue<int>("PORT")}");

            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}
