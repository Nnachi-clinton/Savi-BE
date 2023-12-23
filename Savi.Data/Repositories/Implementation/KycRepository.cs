using Savi.Data.Context;
using Savi.Data.Repositories.Interface;
using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Implementation
{
    public class KycRepository : GenericRepository<Kyc>, IKycRepository
    {
        public KycRepository(SaviDbContext context) : base(context)
        {
        }

        public void AddKycAsync(Kyc kyc)
        {
            AddAsync(kyc);
        }

        public void DeleteAllKycAsync(List<Kyc> kycs)
        {
            DeleteAllAsync(kycs);
        }

        public void DeleteKycAsync(Kyc kyc)
        {
            DeleteAsync(kyc);
        }

        public List<Kyc> FindKycs(Expression<Func<Kyc, bool>> expression)
        {
            return FindAsync(expression);
        }

        public Kyc GetKycByIdAsync(string id)
        {
            return GetByIdAsync(id);
        }

        public List<Kyc> GetKycsAsync()
        {
            return GetAll();
        }

        public void UpdateKycAsync(Kyc kyc)
        {
            UpdateAsync(kyc);
        }
    }
}
