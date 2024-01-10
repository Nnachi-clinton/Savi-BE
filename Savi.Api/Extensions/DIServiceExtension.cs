using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Savi.Core.IServices;
using Savi.Core.Services;
using Savi.Data.Context;
using Savi.Data.Repositories.Implementation;
using Savi.Data.Repositories.Interface;
using Savi.Data.UnitOfWork;
using Savi.Model.Entities;
using Savi.Utility.AutoMapperProfile;

namespace Savi.Api.Extensions
{
    public static class DIServiceExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration config)
        {
            var emailSettings = new EmailSettings();
            config.GetSection("EmailSettings").Bind(emailSettings);
            services.AddSingleton(emailSettings);
            services.AddScoped<IEmailServices, EmailServices>();
            var cloudinarySettings = new CloudinarySettings();
            config.GetSection("CloudinarySettings").Bind(cloudinarySettings);
            services.AddSingleton(cloudinarySettings);
            services.AddScoped(typeof(ICloudinaryServices<>), typeof(CloudinaryServices<>));
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();   
            services.AddIdentity<AppUser, IdentityRole>()
        .AddEntityFrameworkStores<SaviDbContext>()
        .AddDefaultTokenProviders();
            
            services.AddDbContext<SaviDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IPersonalSavings, PersonalSavings>();
            services.AddScoped<ISavingRepository, SavingRepository>();
            services.AddAutoMapper(typeof(MapperProfile));
        }
    }
}