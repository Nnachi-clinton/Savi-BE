using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Savi.Data.Context;
using Savi.Data.Repositories.Interface;
using Savi.Data.Repository.DTO;
using Savi.Model.Entities;

namespace Savi.Data.Repositories.Implementation
{
    public class GroupSavingsMembersRepository : IGroupSavingsMembersRepository
    {
        private readonly SaviDbContext _saviDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public GroupSavingsMembersRepository(SaviDbContext saviDbContext, IMapper mapper, UserManager<AppUser> userManager)
        {
            _saviDbContext = saviDbContext;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<GroupMembersDto>> GetListOfGroupMembersAsync(string UserId)
        {
            var listOfGroups = await _saviDbContext.GroupSavingsMembers.Where(x => x.UserId == UserId).ToListAsync();
            var member = new List<GroupMembersDto>();
            if (listOfGroups.Count > 0)
            {
                foreach (var item in listOfGroups)
                {
                    var user = await _userManager.FindByIdAsync(item.UserId);
                    var mapUser = _mapper.Map<AppUserDto>(user);
                    var mapGroup = _mapper.Map<GroupMembersDto>(item);
                    mapGroup.User = mapUser;
                    member.Add(mapGroup);
                }
                return member;
            }
            return null;
        }
        public async Task<bool> CheckIfUserExist(string UserId, string GroupId)
        {
            var group = await GetListOfGroupMembersAsync(GroupId);
            if (group != null)
            {
                var userExist = group.FirstOrDefault(x => x.UserId == UserId);
                if (userExist != null)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public async Task<ResponseDto<AppUserDto>> GetUserByIdAsync(string userId)
        {
            var user = await _saviDbContext.Users.FindAsync(userId);
            if (user == null)
            {
                var notFoundResponse = new ResponseDto<AppUserDto>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    DisplayMessage = "User not found"
                };
                return notFoundResponse;
            }
            var result = _mapper.Map<AppUserDto>(user);
            var success = new ResponseDto<AppUserDto>
            {
                StatusCode = StatusCodes.Status200OK,
                DisplayMessage = "User Found",
                Result = result
            };
            return success;
        }
        public async Task<int> GetGroupLastUserPosition(string GroupId)
        {
            var group = await _saviDbContext.GroupSavingsMembers.Where(x => x.GroupSavingsId == GroupId).ToListAsync();
            int lastPosition = group.OrderByDescending(user => user.Positions)
                              .Select(user => user.Positions)
                              .FirstOrDefault();
            return lastPosition;
        }
    }
}
