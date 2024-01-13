using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Savi.Core.DTO;
using Savi.Core.IServices;
using Savi.Model;
using Savi.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Savi.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<AppUser> _userManager;
        private readonly EmailServices _emailServices;
        private readonly EmailSettings _emailSettings;
        private readonly ILogger _logger;       
        private readonly SignInManager<AppUser> _signInManager;     

        public AuthenticationService(IConfiguration config, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IOptions<EmailSettings> emailSettings, ILogger<AuthenticationService> logger)        
        {
            _config = config;
            _userManager = userManager;
            _emailServices = new EmailServices(emailSettings);
            _emailSettings = emailSettings.Value;
            _logger = logger;          
            _signInManager = signInManager;           
        }
        public async Task<ApiResponse<string>> LoginAsync(AppUserLoginDTO loginDTO)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginDTO.Email);
                if (user == null)
                    return ApiResponse<string>.Failed(false, "Invalid Email or password.", 400, new List<string> { "Invalid Email or password." });
                if (await _userManager.CheckPasswordAsync(user, loginDTO.Password))
                {
                    var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
                    var jwtToken = GetToken(authClaims);   
                    return ApiResponse<string>.Success(new JwtSecurityTokenHandler().WriteToken(jwtToken), "Login successful", 200);
                }            
                return ApiResponse<string>.Failed(false, "Invalid Email or password.", 400, new List<string> { "Invalid Email or password." });
            }
            catch (Exception ex)
            {                
                return ApiResponse<string>.Failed(false, "An unexpected error occurred during login.", 500, new List<string> { ex.Message });
            }
        }

        public JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:ValidIssuer"],
                audience: _config["JwtSettings:ValidAudience"],
                expires: DateTime.Now.AddDays(2),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
            return token;
        }

        public async Task<ApiResponse<string>> ForgotPasswordAsync(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    return new ApiResponse<string>(false, "User not found or email not confirmed.", StatusCodes.Status404NotFound, null, new List<string>());
                }
                string token = await _userManager.GeneratePasswordResetTokenAsync(user);

                user.PasswordResetToken = token;
                user.ResetTokenExpires = DateTime.UtcNow.AddHours(24);

                await _userManager.UpdateAsync(user);

                var resetPasswordUrl = "http://localhost:3000/reset-password?email=" + Uri.EscapeDataString(email) + "&token=" + Uri.EscapeDataString(token);

                var mailRequest = new MailRequest
                {
                    ToEmail = email,
                    Subject = "Savi Password Reset Instructions",
                    Body = $"Please reset your password by clicking <a href='{resetPasswordUrl}'>here</a>."
                };
                await _emailServices.SendHtmlEmailAsync(mailRequest);

                return new ApiResponse<string>(true, "Password reset email sent successfully.", 200, null, new List<string>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while resolving password change");
                var errorList = new List<string>();
                errorList.Add(ex.Message);
                return new ApiResponse<string>(true, "Error occurred while resolving password change", 500, null, errorList);
            }
        }
        public async Task<ApiResponse<string>> ResetPasswordAsync(string email, string token, string newPassword)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    return new ApiResponse<string>(false, "User not found.", 404, null, new List<string>());
                }
                var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

                if (result.Succeeded)
                {
                    user.PasswordResetToken = null;
                    user.ResetTokenExpires = null;

                    await _userManager.UpdateAsync(user);

                    return new ApiResponse<string>(true, "Password reset successful.", 200, null, new List<string>());
                }
                else
                {
                    return new ApiResponse<string>(false, "Password reset failed.", 400, null, result.Errors.Select(error => error.Description).ToList());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while resetting password");
                var errorList = new List<string> { ex.Message };
                return new ApiResponse<string>(true, "Error occurred while resetting password", 500, null, errorList);
            }
        }

        public async Task<ApiResponse<string>> ChangePasswordAsync(AppUser user, string currentPassword, string newPassword)
        {
            try
            {
                var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

                if (result.Succeeded)
                {
                    return new ApiResponse<string>(true, "Password changed successfully.", 200, null, new List<string>());
                }
                else
                {
                    return new ApiResponse<string>(false, "Password change failed.", 400, null, result.Errors.Select(error => error.Description).ToList());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while changing password");
                var errorList = new List<string> { ex.Message };
                return new ApiResponse<string>(true, "Error occurred while changing password", 500, null, errorList);
            }
        }
        public async Task<ApiResponse<string>> RegisterAsync(AppUserCreateDto appUserCreateDto)
        {
            var validationResults = new List<ValidationResult>();
            var isValidModel = Validator.TryValidateObject(appUserCreateDto, new ValidationContext(appUserCreateDto), validationResults, true);

            if (!isValidModel)
            {
                var errorMessages = validationResults.Select(r => r.ErrorMessage).ToList();
                return new ApiResponse<string>(false, "Invalid input data.", StatusCodes.Status400BadRequest, errorMessages);
            }

            if (appUserCreateDto.Password != appUserCreateDto.ConfirmPassword)
            {
                return new ApiResponse<string>(false, "Passwords do not match.", StatusCodes.Status400BadRequest, new List<string> { "Passwords do not match." });
            }

            var userWithEmailExists = await _userManager.FindByEmailAsync(appUserCreateDto.Email);
            if (userWithEmailExists != null)
            {
                return new ApiResponse<string>(false, "User with this email already exists.", StatusCodes.Status400BadRequest, new List<string> { "User with this email already exists." });
            }

            var userWithPhoneNumberExists = await _userManager.FindByNameAsync(appUserCreateDto.PhoneNumber);
            if (userWithPhoneNumberExists != null)
            {
                return new ApiResponse<string>(false, "User with this phone number already exists.", StatusCodes.Status400BadRequest, new List<string> { "User with this phone number already exists." });
            }

            var appUser = new AppUser
            {
                FirstName = appUserCreateDto.FirstName,
                LastName = appUserCreateDto.LastName,
                Email = appUserCreateDto.Email,
                UserName = appUserCreateDto.Email,
                PhoneNumber = appUserCreateDto.PhoneNumber
            };
            try
            {
                var result = await _userManager.CreateAsync(appUser, appUserCreateDto.Password);
                if (!result.Succeeded)
                {
                    return new ApiResponse<string>(false, "User unable to register.", StatusCodes.Status400BadRequest, new List<string> { "User unable to register." });
                }

                return ApiResponse<string>.Success(appUserCreateDto.Email, $"{appUserCreateDto.FirstName} registered successfully", StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a user " + ex.InnerException);
                var errorList = new List<string> { ex.InnerException?.ToString() ?? ex.Message };
                return new ApiResponse<string>(false, "Error occurred while adding a user.", StatusCodes.Status500InternalServerError, errorList);
            }
        }
    }
   
}

    

   
