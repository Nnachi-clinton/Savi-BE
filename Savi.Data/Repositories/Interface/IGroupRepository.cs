using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Interface
{
    public interface IGroupRepository : IGenericRepository<Group>
    {
        List<Group> GetGroupsAsync();
        void AddGroupAsync(Group group);
        void DeleteGroupAsync(Group group);
        void DeleteAllGroupAsync(List<Group> groups);
        void UpdateGroupAsync(Group group);
        List<Group> FindGroups(Expression<Func<Group, bool>> expression);
        Group GetGroupByIdAsync(string id);
    }
}
