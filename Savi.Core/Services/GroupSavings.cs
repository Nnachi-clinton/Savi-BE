using AutoMapper;
using Microsoft.AspNetCore.Http;
using Savi.Core.DTO;
using Savi.Core.IServices;
using Savi.Data.Context;
using Savi.Data.Repositories.Interface;
using Savi.Model.Entities;
using Savi.Model.Enums;
using System;

namespace Savi.Core.Services
{
    public class GroupSavings : IGroupSavings
    {
        private readonly IMapper _IMapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SaviDbContext _saviDbContext;
        private readonly IGroupSavingsMembersRepository _groupSavingsMembersRepository;
        private readonly ICloudinaryServices<Group> _cloudinaryServices;

        public GroupSavings(IMapper iMapper, IUnitOfWork unitOfWork, ICloudinaryServices<Group> cloudinaryServices, SaviDbContext saviDbContext, IGroupSavingsMembersRepository groupSavingsMembersRepository)
        {
            _IMapper = iMapper;
            _unitOfWork = unitOfWork;
            _cloudinaryServices = cloudinaryServices;
            _saviDbContext = saviDbContext;
            _groupSavingsMembersRepository = groupSavingsMembersRepository;
        }

        public ResponseDto<List<GroupDTO>> GetExploreGroupSavingGroups()
        {
            var response = new ResponseDto<List<GroupDTO>>();

            try
            {
                //var exploreGroupSavingGroups =  _unitOfWork.GroupRepository.GetAll();
                //var waitingGroups = exploreGroupSavingGroups.Where(groupDto => groupDto.GroupStatus == GroupStatus.Waiting).ToList();
                var waitingGroups = _unitOfWork.GroupRepository.GetAll(groupDto => groupDto.GroupStatus == GroupStatus.Waiting);

                if (waitingGroups.Count > 0)
                {
                    var mappedExploreGroups = _IMapper.Map<List<GroupDTO>>(waitingGroups);
                    return new ResponseDto<List<GroupDTO>>()
                    {
                        DisplayMessage = "Success",
                        Result = mappedExploreGroups,
                        StatusCode = 200
                    };                    
                }
                else
                {                    
                    return new ResponseDto<List<GroupDTO>>()
                    {
                        DisplayMessage = "No explore savings group accounts found",
                        Result = null,
                        StatusCode = 404
                    };
                }
            }
            catch (Exception ex)
            {                
                return new ResponseDto<List<GroupDTO>>()
                {
                    DisplayMessage = $"{ex.Message}",
                    Result = null,
                    StatusCode = 500
                };
            }        
        }

        public ResponseDto<GroupDTO> GetExploreGroupSavingDetails(string groupId)
        {
            ArgumentNullException.ThrowIfNull(nameof(groupId));
            try
            {
                var group = _unitOfWork.GroupRepository.GetById(groupId);
                ArgumentNullException.ThrowIfNull(group);
                if (group.GroupStatus == GroupStatus.Waiting)
                {
                    var mappedExploreGroup = _IMapper.Map<GroupDTO>(group);
                    return new ResponseDto<GroupDTO>()
                    {
                        DisplayMessage = "Success",
                        Result = mappedExploreGroup,
                        StatusCode = 200
                    };
                }
                else
                {
                    return new ResponseDto<GroupDTO>()
                    {
                        DisplayMessage = $"{group.SaveName} has been updated to {group.GroupStatus} status.",
                        Result = null,
                        StatusCode = 404
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto<GroupDTO>()
                {
                    DisplayMessage = $"{ex.Message}",
                    Result = null,
                    StatusCode = 500
                };
            }
        }

        public ResponseDto<GroupDTO> GetGroupSavingAccountDetails(string groupId)
        {
            ArgumentNullException.ThrowIfNull(nameof(groupId));
            try
            {
                var group = _unitOfWork.GroupRepository.GetById(groupId);
                ArgumentNullException.ThrowIfNull(group);
                if (group.GroupStatus == GroupStatus.OnGoing)
                {
                    var mappedExploreGroup = _IMapper.Map<GroupDTO>(group);
                    return new ResponseDto<GroupDTO>()
                    {
                        DisplayMessage = "Success",
                        Result = mappedExploreGroup,
                        StatusCode = 200
                    };
                }
                else
                {
                    return new ResponseDto<GroupDTO>()
                    {
                        DisplayMessage = $"{group.SaveName} has been updated to {group.GroupStatus} status.",
                        Result = null,
                        StatusCode = 404
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto<GroupDTO>()
                {
                    DisplayMessage = $"{ex.Message}",
                    Result = null,
                    StatusCode = 500
                };
            }
        }
        public ResponseDto<List<GroupDTO>> GetListOfActiveSavingsGroups()
        {
            var response = new ResponseDto<List<GroupDTO>>();

            try
            {
                //var activeGroupSavingGroups = _unitOfWork.GroupRepository.GetAll();
                //var ongoingGroups = activeGroupSavingGroups.Where(groupDto => groupDto.GroupStatus == GroupStatus.OnGoing).ToList();
                var ongoingGroups = _unitOfWork.GroupRepository.GetAll(groupDto => groupDto.GroupStatus == GroupStatus.OnGoing);

                if (ongoingGroups.Count > 0)
                {
                    var mappedOngoingGroups = _IMapper.Map<List<GroupDTO>>(ongoingGroups);
                    return new ResponseDto<List<GroupDTO>>()
                    {
                        DisplayMessage = "Success",
                        Result = mappedOngoingGroups,
                        StatusCode = 200
                    };
                }

                else
                {
                    return new ResponseDto<List<GroupDTO>>()
                    {
                        DisplayMessage = "No Active savings group accounts found",
                        Result = null,
                        StatusCode = 404
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<GroupDTO>>()
                {
                    DisplayMessage = $"{ex.Message}",
                    Result = null,
                    StatusCode = 500
                };
            }
        }

        public async Task<ResponseDto<string>> CreateSavingsGroup(GroupDTO2 dto)
        {
            try
            {
                var userExist = _saviDbContext.Users.FirstOrDefault(x => x.Id == dto.UserId);
                ArgumentNullException.ThrowIfNull(nameof(userExist));
                var newGroupSavings = _IMapper.Map<Group>(dto);
                newGroupSavings.MemberCount = 1;
                newGroupSavings.MaxNumberOfParticipants = 5;
                newGroupSavings.GroupStatus = GroupStatus.Waiting;
                var result = await _unitOfWork.GroupRepository.AddGroupAsync2(newGroupSavings);            
                if (result != null)
                {
                    var newGroupMember = new GroupSavingsMembers()
                    {
                        Positions = 1,
                        IsGroupOwner = true,
                        IsPaid = false,
                        GroupSavingsId = newGroupSavings.Id,
                        UserId = dto.UserId
                    };
                    var res = await _groupSavingsMembersRepository.CreateSavingsGroupMembersAsync(newGroupMember);
                    var imageUrl = await _cloudinaryServices.UploadImage(result.Id, dto.FormFile);
                    result.SafePortraitImageURL = imageUrl;
                    _unitOfWork.GroupRepository.UpdateGroupAsync(result);
                    _unitOfWork.SaveChanges();
                    if (res)
                    {
                            return new ResponseDto<string>()
                        {
                            DisplayMessage = $"{result.SaveName} Group created successfully",
                            StatusCode = 200,
                            Result = null,
                        };
                    }
                }
                return new ResponseDto<string>()
                {
                    DisplayMessage = "Failed to create Group",
                    StatusCode = 400,
                    Result = null,
                };
            }
            catch (Exception ex)
            {

                return new ResponseDto<string>()
                {
                    DisplayMessage = $"{ex.Message}",
                    Result = null,
                    StatusCode = 500
                };
            }
        }

        
    }
}
    

