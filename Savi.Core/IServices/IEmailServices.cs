using MimeKit;
using Savi.Model.Entities;
namespace Savi.Core.IServices
{
    public interface IEmailServices
    {
        Task SendHtmlEmailAsync(MailRequest mailRequest);
        void AttachFile(BodyBuilder builder, string filePath, string fileName);
    }
}
