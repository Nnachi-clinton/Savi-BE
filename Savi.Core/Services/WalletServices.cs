﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Savi.Core.DTO;
using Savi.Core.IServices;
using Savi.Data.Repositories.Interface;
using Savi.Model;
using Savi.Model.Entities;
using Savi.Utility;

namespace Savi.Core.Services
{
    public class WalletServices : IWalletServices
    {
        private readonly ILogger _logger;
        private readonly UserManager<AppUser> userManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WalletServices(ILogger<WalletServices> logger,UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _logger = logger;
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
            _httpClient = new HttpClient();
            _configuration = configuration;
            string secretKey = _configuration["PaystackApi:SecretKey"];
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {secretKey}");
        }     


        public async Task<ApiResponse<string>> CreateWallet(string userId)
        {
            try
            {
                var user = await userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return new ApiResponse<string>(false, "User not found.", StatusCodes.Status400BadRequest, new List<string> { "User not found." });
                }
                var setWallet = new SetWalletAccountNumber();
                var wallet = new Wallet
                {
                    Id = Guid.NewGuid().ToString(),
                    WalletNumber = setWallet.SetWalletNumber(user.PhoneNumber),
                    Balance = 0,
                    AppUserId = user.Id,
                    TransactionPin = "1234"
                };
                await unitOfWork.WalletRepository.AddWalletAsync(wallet);
                unitOfWork.SaveChanges();
                return new ApiResponse<string>(true, "Wallet created successfully.", StatusCodes.Status201Created, new List<string> { "Wallet created successfully." });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a wallet. " + ex.InnerException);
                var errorList = new List<string> { ex.InnerException?.ToString() ?? ex.Message };
                return new ApiResponse<string>(false, "Error occurred while creating a wallet.", StatusCodes.Status500InternalServerError, errorList);
            }
        }
        public async Task<string> VerifyTransaction(string referenceCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(referenceCode))
                {
                    throw new Exception("Please provide a valid reference number");
                }
                HttpResponseMessage response = await _httpClient.GetAsync($"https://api.paystack.co/transaction/verify/{referenceCode}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<PaystackResponse>(content);
                    if (result.Status)
                    {
                        var data = result.Data;
                        if (data.Status == "success")                        {
                            var amount = data.Amount / 100;
                            var email = data.Customer.Email;
                           var updateWallet = await UpdateWallet(email, amount); //email to be changed to userId, remember
                             var walletFunding = new WalletFunding()
                            {
                                FundAmount = amount,
                                Reference = referenceCode,
                                WalletNumber = updateWallet.WalletNumber,
                                WalletId = updateWallet.Id,
                                CumulativeAmount = updateWallet.Balance,
                                TransactionType = Model.Enums.TransactionType.Credit,
                            };
                            await unitOfWork.WalletFundingRepository.AddAsync(walletFunding);
                            unitOfWork.SaveChanges();
                           return ($"Payment of {amount} Naira from {email} was successful!");
                        }
                        else
                        {
                            return($"Payment was not successful. Status: {data.Status}");
                        }
                    }
                    else
                    {                    
                        return($"Paystack API returned an error. Message: {result.Message}");
                    }
                }
                else
                {
                    return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
                }
            }
            catch (HttpRequestException ex)
            {
                return $"HttpRequestException: {ex.Message}";

            }
        }
        public async Task<ResponseDto<WalletDto>> GetUserWalletAsync(string userId)
        {
            var wallet = await unitOfWork.WalletRepository.GetByIdAsync(userId);

            if (wallet == null)
            {
                return new ResponseDto<WalletDto>()
                {
                    StatusCode = 404,                     
                    DisplayMessage = "User does not have a wallet.",
                };
            }
            var walletDto = new WalletDto
            {
                Currency = wallet.Currency,
                AppUserId = wallet.AppUserId,
                Reference = wallet.Reference,
                Balance = wallet.Balance,
                TransactionPin = wallet.TransactionPin,
            };
            return new ResponseDto<WalletDto>()
            {
                StatusCode = 200,
                DisplayMessage = "User's wallet retrieved successfully.",
                Result = walletDto,
            };
        }
        private async Task<Wallet> UpdateWallet(string userId, decimal amount)
        {
            var wallet = await GetUserWalletAsync(userId);
            var updateWallet = new Wallet()
            {
                Balance = wallet.Result.Balance + amount,
                ModifiedAt = DateTime.UtcNow,
            };
            unitOfWork.WalletRepository.UpdateAsync(updateWallet);
            unitOfWork.SaveChanges();
            return updateWallet;
        }

    }

}

