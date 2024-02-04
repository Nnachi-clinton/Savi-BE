using Savi.Data.Repository.DTO;

namespace Savi.Data.Repositories.Interface
{
    public interface IGroupSavingsMembersRepository
    {
        Task<List<GroupMembersDto>> GetListOfGroupMembersAsync(string UserId);
        Task<bool> CheckIfUserExist(string UserId, string GroupId);
        Task<ResponseDto<AppUserDto>> GetUserByIdAsync(string UserId);
        Task<int> GetGroupLastUserPosition(string GroupId);
    }
}
