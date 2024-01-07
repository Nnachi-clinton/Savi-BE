using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Interface
{
    public interface IGroupRepository : IGenericRepository<Group>
    {
        List<Group> GetGroupsAsync();
        Task AddGroupAsync(Group group);
        Task DeleteGroupAsync(Group group);
        Task DeleteAllGroupAsync(List<Group> groups);
        void UpdateGroupAsync(Group group);
        List<Group> FindGroups(Expression<Func<Group, bool>> expression);
        Task<Group> GetGroupByIdAsync(string id);
    }
}
