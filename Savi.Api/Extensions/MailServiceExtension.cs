using Savi.Model.Entities;

namespace Savi.Api.Extensions
{
    public static class MailServiceExtension
    {
        public static void AddMailService(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<EmailSettings>(config.GetSection("EmailSettings"));
        }
    }
}
