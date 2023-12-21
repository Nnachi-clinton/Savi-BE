﻿using Savi.Core.IServices;
using Savi.Core.Services;
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

        }
    }
}