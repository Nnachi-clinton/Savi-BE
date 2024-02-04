using Savi.Core.DTO;
using Savi.Data.Repositories.Interface;
using Savi.Model.Entities;

namespace Savi.Core.Services
{
    public class GroupSavingsMembersServices
    {
        private readonly IGroupSavingsMembersRepository _groupSavingsMembersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GroupSavingsMembersServices(IGroupSavingsMembersRepository groupSavingsMembersRepository, IUnitOfWork unitOfWork)
        {
            _groupSavingsMembersRepository = groupSavingsMembersRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseDto<bool>> JoinGroupSavingsAsync(string UserId, string GroupId)
        {
            try
            {
                var member = await _groupSavingsMembersRepository.GetUserByIdAsync(UserId);
                if (member == null)
                {
                    return new ResponseDto<bool>()
                    {
                        DisplayMessage = "User not found",
                        StatusCode = 401,
                        Result = false
                    };
                }
                var memberExist = await _groupSavingsMembersRepository.CheckIfUserExist(UserId, GroupId);
                if (memberExist)
                {
                    return new ResponseDto<bool>()
                    {
                        DisplayMessage = "You are already a member",
                        StatusCode = 401,
                        Result = false
                    };
                }
                var group = await _unitOfWork.GroupRepository.GetGroupByIdAsync(GroupId);
                if (group != null)
                {
                    var newGroupMember = new GroupSavingsMembers();
                    var lastPosition = await _groupSavingsMembersRepository.GetGroupLastUserPosition(GroupId);
                    if (lastPosition == 4)
                    {

                    }
                }
                return new ResponseDto<bool>()
                {
                    DisplayMessage = "Group doesn't exist",
                    StatusCode = 402,
                    Result = false
                };
            }
            catch (Exception ex)
            {

                return new ResponseDto<bool>()
                {
                    DisplayMessage = ex.Message,
                    StatusCode = 500,
                    Result = false
                };
            }

        }




    }
}
