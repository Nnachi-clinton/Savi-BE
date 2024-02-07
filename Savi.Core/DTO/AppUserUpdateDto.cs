using Microsoft.AspNetCore.Http;

namespace Savi.Core.DTO
{
    public class AppUserUpdateDto
    {
        public string UserId { get; set; }
        //public string Email { get; set; }
        public IFormFile formFile { get; set; }
    }
}
