using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Interface
{
    public interface IOtpRepository : IGenericRepository<Otp>
    {
        List<Otp> GetOtpsAsync();
        Task AddOtpAsync(Otp otp);
        Task DeleteOtpAsync(Otp otp);
        Task DeleteAllOtpAsync(List<Otp> otps);
        void UpdateOtpAsync(Otp otp);
        List<Otp> FindOtps(Expression<Func<Otp, bool>> expression);
        Task<Otp> GetOtpByIdAsync(string id);
    }
}
