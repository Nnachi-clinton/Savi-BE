using Savi.Data.Repository.DTO;
using Savi.Model.Entities;

namespace Savi.Data.Repositories.Interface
{
    public interface IGroupSavingsMembersRepository
    {
        Task<List<GroupMembersDto2>> GetListOfGroupMembersAsync(string UserId);
        Task<bool> CheckIfUserExist(string UserId, string GroupId);
        Task<ResponseDto2<AppUserDto2>> GetUserByIdAsync(string UserId);
        Task<int> GetGroupLastUserPosition(string GroupId);
        Task<bool> CreateSavingsGroupMembersAsync(GroupSavingsMembers groupSavingsMembers);
    }
}
