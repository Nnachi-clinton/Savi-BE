using Savi.Core.IServices;
using Savi.Core.Services;
using Savi.Data.Repositories.Interface;
using Savi.Data.UnitOfWork;
using Savi.Model.Entities;

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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}