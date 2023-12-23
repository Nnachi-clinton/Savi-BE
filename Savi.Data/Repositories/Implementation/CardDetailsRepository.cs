using Savi.Data.Context;
using Savi.Data.Repositories.Interface;
using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Implementation
{
    public class CardDetailsRepository : GenericRepository<CardDetail>, ICardDetailsRepository
    {
        public CardDetailsRepository(SaviDbContext context) : base(context)
        {
        }

        public void AddCardDetailAsync(CardDetail cardDetail)
        {
            AddAsync(cardDetail);
        }

        public void DeleteAllCardDetailAsync(List<CardDetail> cardDetails)
        {
            DeleteAllAsync(cardDetails);
        }

        public void DeleteCardDetailAsync(CardDetail cardDetail)
        {
            DeleteAsync(cardDetail);
        }

        public List<CardDetail> FindCardDetails(Expression<Func<CardDetail, bool>> expression)
        {
            return FindAsync(expression);
        }

        public CardDetail GetCardDetailByIdAsync(string id)
        {
            return  GetByIdAsync(id);
        }

        public List<CardDetail> GetCardDetailsAsync()
        {
            return GetAll();
        }

        public void UpdateCardDetailAsync(CardDetail cardDetail)
        {
            UpdateAsync(cardDetail);
        }
    }
}
