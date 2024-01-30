using Savi.Core.DTO;
using Savi.Model.Entities;

namespace Savi.Core.IServices
{
    public interface IPersonalSavings
    {
        Task<ResponseDto<string>> SetPersonal_Savings_Target(PersonalSavingsDTO saving, string userId);
        Task<ResponseDto<List<Saving>>> Get_ListOf_All_UserTargets(string UserId);
    }
}
