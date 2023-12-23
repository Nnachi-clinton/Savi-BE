using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Interface
{
    public interface IKycRepository : IGenericRepository<Kyc>
    {
        List<Kyc> GetKycsAsync();
        void AddKycAsync(Kyc kyc);
        void DeleteKycAsync(Kyc kyc);
        void DeleteAllKycAsync(List<Kyc> kycs);
        void UpdateKycAsync(Kyc kyc);
        List<Kyc> FindKycs(Expression<Func<Kyc, bool>> expression);
        Task<Kyc> GetKycByIdAsync(string id);
    }
}
