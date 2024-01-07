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

        public async Task AddGroupAsync(Group group)
        {
            await AddAsync(group);
        }

        public async Task DeleteAllGroupAsync(List<Group> groups)
        {
           await DeleteAllAsync(groups);
        }

        public async Task DeleteGroupAsync(Group group)
        {
           await DeleteAsync(group);
        }

        public List<Group> FindGroups(Expression<Func<Group, bool>> expression)
        {
            return FindAsync(expression);
        }
        public async Task<Group> GetGroupByIdAsync(string id)
        {
            return await GetByIdAsync(id);
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
