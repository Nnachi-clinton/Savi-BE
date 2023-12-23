using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Interface
{
    public interface IOtpRepository : IGenericRepository<Otp>
    {
        List<Otp> GetOtpsAsync();
        void AddOtpAsync(Otp otp);
        void DeleteOtpAsync(Otp otp);
        void DeleteAllOtpAsync(List<Otp> otps);
        void UpdateOtpAsync(Otp otp);
        List<Otp> FindOtps(Expression<Func<Otp, bool>> expression);
        Otp GetOtpByIdAsync(string id);
    }
}
