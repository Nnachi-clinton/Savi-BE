using Savi.Core.DTO;
using Savi.Core.IServices;
using Savi.Data.Repositories.Interface;
using Savi.Model.Entities;
using Savi.Model.Enums;

namespace Savi.Core.Services
{
    public class PersonalSavings : IPersonalSavings
    {
        private readonly ISavingRepository _savingRepository;

        public PersonalSavings(ISavingRepository savingRepository)
        {
            _savingRepository = savingRepository;
        }

        public async Task<ResponseDto<string>> SetPersonal_Savings_Target(Saving saving)
        {
            var response = new ResponseDto<string>();
            try
            {
                if (saving.FundFrequency== FundFrequency.Daily)
                {
                    saving.NextRuntime = DateTime.Today;

                    var x = saving.TargetAmount;
                    var y = saving.AmountToAdd;
                    if (x <= 0 || y <= 0)
                    {
                        response.DisplayMessage = "Failed";
                        response.Result = "TargetAmount or AmountToAdd cannot be less than or equal to zero";
                        response.StatusCode = 400;
                        return response;
                    }
                    var z = x / y;
                    saving.EndDate = DateTime.Now.AddDays(((double)z));
                    saving.WithdrawalDate = saving.EndDate.AddDays(1);
                    saving.TargetName = saving.TargetName;
                    var newTarget = await _savingRepository.CreateSavings(saving);
                    if (newTarget)
                    {
                        response.DisplayMessage = "Success";
                        response.Result = $"Your target of amount {saving.TargetAmount} has been successfully created";
                        response.StatusCode = 200;
                        return response;
                    }
                    response.DisplayMessage = "Failed";
                    response.Result = $"Unable to create target of amount{saving.TargetAmount}";
                    response.StatusCode = 400;
                    return response;
                }
                else if (saving.FundFrequency == FundFrequency.Weekly)
                {
                    saving.NextRuntime = DateTime.Today;
                    var x = saving.TargetAmount;
                    var y = saving.AmountToAdd;
                    if (x <= 0 || y <= 0)
                    {
                        response.DisplayMessage = "Failed";
                        response.Result = "TargetAmount or AmountToAdd cannot be less than or equal to zero";
                        response.StatusCode = 400;
                        return response;
                    }
                    var z = (x / y) * 6;
                    saving.EndDate = DateTime.Now.AddDays(((double)z));
                    saving.WithdrawalDate = saving.EndDate.AddDays(1);
                    saving.TargetName = saving.TargetName;
                    var newTarget = await _savingRepository.CreateSavings(saving);
                    if (newTarget)
                    {
                        response.DisplayMessage = "Success";
                        response.Result = $"Your target of amount {saving.TargetAmount} has been successfully created";
                        response.StatusCode = 200;
                        return response;
                    }
                    response.DisplayMessage = "Failed";
                    response.Result = $"Unable to create target of amount{saving.TargetAmount}";
                    response.StatusCode = 400;
                    return response;
                }
                else
                {
                    saving.NextRuntime = DateTime.Today;
                    var x = saving.TargetAmount;
                    var y = saving.AmountToAdd;
                    if (x <= 0 || y <= 0)
                    {
                        response.DisplayMessage = "Failed";
                        response.Result = "TargetAmount or AmountToAdd cannot be less than or equal to zero";
                        response.StatusCode = 400;
                        return response;
                    }
                    var z = (x / y) * 30;
                    saving.EndDate = DateTime.Now.AddDays(((double)z));
                    saving.WithdrawalDate = saving.EndDate.AddDays(1);
                    saving.TargetName = saving.TargetName;
                    var newTarget = await _savingRepository.CreateSavings(saving);
                    if (newTarget)
                    {
                        response.DisplayMessage = "Success";
                        response.Result = $"Your target of amount {saving.TargetAmount} has been successfully created";
                        response.StatusCode = 200;
                        return response;
                    }
                    response.DisplayMessage = "Failed";
                    response.Result = $"Unable to create target of amount{saving.TargetAmount}";
                    response.StatusCode = 400;
                    return response;
                }
            }
            catch (Exception ex)
            {

                response.DisplayMessage = ex.Message;
                response.Result = $"Unable to create target of amount{saving.TargetAmount}";
                response.StatusCode = 400;
                return response;
            }

        }
    }
}
