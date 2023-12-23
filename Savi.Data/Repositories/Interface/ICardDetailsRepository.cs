using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Interface
{
    public interface ICardDetailsRepository : IGenericRepository<CardDetail>
    {
        List<CardDetail> GetCardDetailsAsync();
        void AddCardDetailAsync(CardDetail cardDetail);
        void DeleteCardDetailAsync(CardDetail cardDetail);
        void DeleteAllCardDetailAsync(List<CardDetail> cardDetails);
        void UpdateCardDetailAsync(CardDetail cardDetail);
        List<CardDetail> FindCardDetails(Expression<Func<CardDetail, bool>> expression);
        CardDetail GetCardDetailByIdAsync(string id);
    }
}
