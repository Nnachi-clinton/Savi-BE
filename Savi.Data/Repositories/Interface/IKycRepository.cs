using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Interface
{
    public interface IKycRepository : IGenericRepository<Kyc>
    {
        List<Kyc> GetKycsAsync();
        Task AddKycAsync(Kyc kyc);
        Task DeleteKycAsync(Kyc kyc);
        Task DeleteAllKycAsync(List<Kyc> kycs);
        void UpdateKycAsync(Kyc kyc);
        List<Kyc> FindKycs(Expression<Func<Kyc, bool>> expression);
        Task<Kyc> GetKycByIdAsync(string id);
    }
}
