using Savi.Data.Context;
using Savi.Data.Repositories.Interface;
using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Implementation
{
    public class GroupTransactionRepository : GenericRepository<GroupTransaction>, IGroupTransactionRepository
    {
        public GroupTransactionRepository(SaviDbContext context) : base(context)
        {
        }

        public void AddGroupTransactionAsync(GroupTransaction groupTransaction)
        {
            AddAsync(groupTransaction);
        }

        public void DeleteAllGroupTransactionAsync(List<GroupTransaction> groupTransactions)
        {
            DeleteAllAsync(groupTransactions);
        }

        public void DeleteGroupTransactionAsync(GroupTransaction groupTransaction)
        {
            DeleteAsync(groupTransaction);
        }

        public List<GroupTransaction> FindGroupTransactions(Expression<Func<GroupTransaction, bool>> expression)
        {
            return FindAsync(expression);
        }

        public GroupTransaction GetGroupTransactionByIdAsync(string id)
        {
            return GetByIdAsync(id);
        }

        public List<GroupTransaction> GetGroupTransactionsAsync()
        {
            return GetAll();
        }

        public void UpdateGroupTransactionAsync(GroupTransaction groupTransaction)
        {
            UpdateAsync(groupTransaction);
        }
    }
}
