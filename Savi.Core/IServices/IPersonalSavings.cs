using Savi.Core.DTO;
using Savi.Model.Entities;

namespace Savi.Core.IServices
{
    public interface IPersonalSavings
    {
        Task<ResponseDto<string>> SetPersonal_Savings_Target(Saving saving);
    }
}
