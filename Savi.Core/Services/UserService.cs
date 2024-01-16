using AutoMapper;
using Microsoft.AspNetCore.Identity;
//using Microsoft.PowerBI.Api.Models;
using Savi.Core.DTO;
using Savi.Core.IServices;
using Savi.Model;
using Savi.Model.Entities;

namespace Savi.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ApiResponse<AppUserDto>> GetUserByIdAsync(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                return user != null
                    ? SuccessResponse(_mapper.Map<AppUserDto>(user), "User found.")
                    : NotFoundResponse();
            }
            catch (Exception ex)
            {
                return ErrorResponse(ex);
            }
        }

        private ApiResponse<AppUserDto> NotFoundResponse()
            => ApiResponse<AppUserDto>.Failed(false, "User not found.", 404, new List<string> { "User not found." });

        private ApiResponse<AppUserDto> SuccessResponse(AppUserDto userDto, string message)
            => ApiResponse<AppUserDto>.Success(userDto, message, 200);

        private ApiResponse<AppUserDto> ErrorResponse(Exception ex)
            => ApiResponse<AppUserDto>.Failed(false, "An error occurred while retrieving the user.", 500, new List<string> { ex.Message });
    }
}
