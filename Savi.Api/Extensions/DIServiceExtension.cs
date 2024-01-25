﻿using Microsoft.AspNetCore.Http.Features;
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
using Savi.Api.AutoMapperProfile;

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
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IKycService, KycService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<SaviDbContext>()
            .AddDefaultTokenProviders();
            
            services.AddDbContext<SaviDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IPersonalSavings, PersonalSavings>();
            services.AddScoped<ISavingRepository, SavingRepository>();
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddScoped<IWalletServices, WalletServices>();
            //services.AddTransient<WalletServices>(provider =>
            //{
            //    IConfiguration configuration = provider.GetRequiredService<IConfiguration>();
            //    return new WalletServices(configuration);
            //});
            services.AddTransient<WalletServices>();

        }
    }
}