using Microsoft.EntityFrameworkCore;
using Savi.Api.Configurations;
using Savi.Api.Extensions;

namespace Savi.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var configuration = builder.Configuration;
            builder.Services.AddLoggingConfiguration(configuration);
            
            builder.Services.AddControllers();
            builder.Services.AddMailService(configuration);
            builder.Services.AddDependencies(configuration);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

			//         builder.Services.AddDbContext<SaviDbContext>(options =>
			//options.UseSqlServer(configuration.GetConnectionString("SaviSavings")));



			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddCors();
			//builder.Services.AddAutoMapper(typeof(MapperProfile));



			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI( c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Savi v1"));
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
