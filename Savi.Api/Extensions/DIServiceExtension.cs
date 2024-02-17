﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http.Features;
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
using Hangfire;

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
            services.AddScoped<IFundingService, FundingService>();
            services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<SaviDbContext>()
            .AddDefaultTokenProviders();
            services.AddScoped<IAdminService, AdminService>();
            services.AddDbContext<SaviDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IPersonalSavings, PersonalSavings>();
            services.AddScoped<IGroupSavings, GroupSavings>();
            services.AddScoped<ISavingRepository, SavingRepository>();
            services.AddScoped<IWalletServices, WalletServices>();
            services.AddScoped<IWalletService, WalletService>();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.LoginPath = "/api/Authentication/Login"; 
            })
            .AddGoogle(options =>
            {
                options.ClientId = config["Google:ClientId"];
                options.ClientSecret = config["Google:ClientSecret"];
                options.CallbackPath = "/api/Authentication/signin-google/token"; 
            });
            //services.AddTransient<WalletServices>(provider =>
            //{
            //    IConfiguration configuration = provider.GetRequiredService<IConfiguration>();
            //    return new WalletServices(configuration);
            //});
            services.AddTransient<WalletServices>();
            services.AddHangfire(confi => confi.UseSqlServerStorage(config.GetConnectionString("DefaultConnection")));
            services.AddHangfireServer();
            services.AddScoped<IAutoSaveBackgroundService,AutoSaveBackgroundService>();
            services.AddScoped<IFundingAnalyticsBackgroundServices, FundingAnalyticsBackgroundServices>();
            services.AddScoped<IGroupSavingsMembersServices, GroupSavingsMembersServices>();
            services.AddScoped<IGroupSavingsMembersRepository, GroupSavingsMembersRepository>();

        }
    }
}