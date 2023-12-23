using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Interface
{
    public interface IGroupTransactionRepository : IGenericRepository<GroupTransaction>
    {
        List<GroupTransaction> GetGroupTransactionsAsync();
        void AddGroupTransactionAsync(GroupTransaction groupTransaction);
        void DeleteGroupTransactionAsync(GroupTransaction groupTransaction);
        void DeleteAllGroupTransactionAsync(List<GroupTransaction> groupTransactions);
        void UpdateGroupTransactionAsync(GroupTransaction groupTransaction);
        List<GroupTransaction> FindGroupTransactions(Expression<Func<GroupTransaction, bool>> expression);
        GroupTransaction GetGroupTransactionByIdAsync(string id);
    }
}
