using Savi.Data.Context;
using Savi.Data.Repositories.Interface;
using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Implementation
{
    public class KycRepository : GenericRepository<Kyc>, IKycRepository
    {
        public KycRepository(SaviDbContext context) : base(context) {}

        public async Task AddKycAsync(Kyc kyc) => await AddAsync(kyc);

        public async Task DeleteKycAsync(Kyc kyc) => await DeleteAsync(kyc);

        public List<Kyc> FindKycs(Expression<Func<Kyc, bool>> expression) => FindAsync(expression);

        public async Task<Kyc> GetKycByIdAsync(string id) => await GetByIdAsync(id);

        public List<Kyc> GetAllKycs() => GetAll();

        public void UpdateKyc(Kyc kyc) => UpdateAsync(kyc);
    }
}
