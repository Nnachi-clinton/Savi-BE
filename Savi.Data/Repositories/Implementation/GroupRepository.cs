using Savi.Data.Context;
using Savi.Data.Repositories.Interface;
using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Implementation
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(SaviDbContext context) : base(context)
        {
        }

        public void AddGroupAsync(Group group)
        {
            AddAsync(group);
        }

        public void DeleteAllGroupAsync(List<Group> groups)
        {
            DeleteAllAsync(groups);
        }

        public void DeleteGroupAsync(Group group)
        {
            DeleteAsync(group);
        }

        public List<Group> FindGroups(Expression<Func<Group, bool>> expression)
        {
            return FindAsync(expression);
        }

        public Group GetGroupByIdAsync(string id)
        {
            return  GetByIdAsync(id);
        }

        public List<Group> GetGroupsAsync()
        {
            return GetAll();
        }

        public void UpdateGroupAsync(Group group)
        {
            UpdateAsync(group);
        }
    }
}
