using Savi.Data.Context;
using Savi.Data.Repositories.Interface;
using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Implementation
{
    public class OtpRepository : GenericRepository<Otp>, IOtpRepository
    {
        public OtpRepository(SaviDbContext context) : base(context)
        {
        }

        public void AddOtpAsync(Otp otp)
        {
            AddAsync(otp);
        }

        public void DeleteAllOtpAsync(List<Otp> otps)
        {
            DeleteAllAsync(otps);
        }

        public void DeleteOtpAsync(Otp otp)
        {
            DeleteAsync(otp);
        }

        public List<Otp> FindOtps(Expression<Func<Otp, bool>> expression)
        {
            return FindAsync(expression).ToList();
        }

        public Otp GetOtpByIdAsync(string id)
        {
            return GetByIdAsync(id);
        }

        public List<Otp> GetOtpsAsync()
        {
            return GetAll();
        }

        public void UpdateOtpAsync(Otp otp)
        {
            UpdateAsync(otp);
        }
    }
}
