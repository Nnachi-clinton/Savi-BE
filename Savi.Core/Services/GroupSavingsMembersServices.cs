using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Math.EC.Multiplier;
using Savi.Core.DTO;
using Savi.Core.IServices;
using Savi.Data.Repositories.Implementation;
using Savi.Data.Repositories.Interface;
using Savi.Model.Entities;
using Savi.Model.Enums;
using System.Net;

namespace Savi.Core.Services
{
    public class GroupSavingsMembersServices : IGroupSavingsMembersServices
    {
        private readonly IGroupSavingsMembersRepository _groupSavingsMembersRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GroupSavingsMembersServices> _logger;


        public GroupSavingsMembersServices(IGroupSavingsMembersRepository groupSavingsMembersRepository, IUnitOfWork unitOfWork, ILogger<GroupSavingsMembersServices> logger)
        {
            _groupSavingsMembersRepository = groupSavingsMembersRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
       
        //public async Task<ResponseDto<bool>> JoinGroupSavingsAsync(string userId, string groupId)
        //{
        //    try
        //    {
        //        var member = await _groupSavingsMembersRepository.GetUserByIdAsync(userId);
        //        if (member == null)
        //        {
        //            return new ResponseDto<bool>()
        //            {
        //                DisplayMessage = "User not found",
        //                StatusCode = 401,
        //                Result = false
        //            };
        //        }

        //        var memberExist = await _groupSavingsMembersRepository.CheckIfUserExist(userId, groupId);
        //        if (memberExist)
        //        {
        //            return new ResponseDto<bool>()
        //            {
        //                DisplayMessage = "You are already a member",
        //                StatusCode = 401,
        //                Result = false
        //            };
        //        }

        //        var group = await _unitOfWork.GroupRepository.GetGroupByIdAsync(groupId);
        //        if (group == null)
        //        {
        //            return new ResponseDto<bool>()
        //            {
        //                DisplayMessage = "Group doesn't exist",
        //                StatusCode = 401,
        //                Result = false
        //            };
        //        }

        //        var lastPosition = await _groupSavingsMembersRepository.GetGroupLastUserPosition(groupId);
        //        var isGroupFull = lastPosition >= group.MemberCount || lastPosition >= 5;
        //        if (isGroupFull)
        //        {
        //            return new ResponseDto<bool>()
        //            {
        //                DisplayMessage = $"{group.SaveName} is already full",
        //                StatusCode = 402,
        //                Result = false
        //            };
        //        }

        //        var newGroupMember = new GroupSavingsMembers
        //        {
        //            Positions = lastPosition,
        //            UserId = userId,
        //            IsGroupOwner = false,
        //            GroupSavingsId = groupId
        //        };

        //        var memberToAdd = await _groupSavingsMembersRepository.CreateSavingsGroupMembersAsync(newGroupMember);
        //        if (memberToAdd)
        //        {
        //            UpdateGroupDetails(group);
        //            return new ResponseDto<bool>()
        //            {
        //                DisplayMessage = $"Successfully added to {group.SaveName} group",
        //                StatusCode = 200,
        //                Result = true
        //            };
        //        }

        //        return new ResponseDto<bool>()
        //        {
        //            DisplayMessage = $"Unable to add you to {group.SaveName}",
        //            StatusCode = 400,
        //            Result = false
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "An error occurred while joining group savings");
        //        return new ResponseDto<bool>()
        //        {
        //            DisplayMessage = "An error occurred while processing your request",
        //            StatusCode = 401,
        //            Result = false
        //        };
        //    }
        //}      

        public async Task<ResponseDto<bool>> JoinGroupSavingsAsync(string userId, string groupId)
        {
            try
            {
                var member = await _groupSavingsMembersRepository.GetUserByIdAsync(userId);
                if (member == null)
                {
                    return new ResponseDto<bool>()
                    {
                        DisplayMessage = "User not found",
                        StatusCode = 404,
                        Result = false
                    };
                }

                var memberExist = await _groupSavingsMembersRepository.CheckIfUserExist(userId, groupId);
                if (memberExist)
                {
                    return new ResponseDto<bool>()
                    {
                        DisplayMessage = "You are already a member",
                        StatusCode = 400,
                        Result = false
                    };
                }

                var group = await _unitOfWork.GroupRepository.GetGroupByIdAsync(groupId);
                if (group == null)
                {
                    return new ResponseDto<bool>()
                    {
                        DisplayMessage = "Group doesn't exist",
                        StatusCode = 400,
                        Result = false
                    };
                }

                var lastPosition = await _groupSavingsMembersRepository.GetGroupLastUserPosition(groupId);
                if (lastPosition == 4) 
                {
                     UpdateGroupDetails(group);
                }

                var isGroupFull = lastPosition >= group.MaxNumberOfParticipants ;
                if (isGroupFull)
                {
                    return new ResponseDto<bool>()
                    {
                        DisplayMessage = $"{group.SaveName} is already full",
                        StatusCode = 400,
                        Result = false
                    };
                }

                var newGroupMember = new GroupSavingsMembers
                {
                    Positions = lastPosition+1,
                    UserId = userId,
                    IsGroupOwner = false,
                    GroupSavingsId = groupId
                };

                var memberToAdd = await _groupSavingsMembersRepository.CreateSavingsGroupMembersAsync(newGroupMember);
                if (memberToAdd)
                {
                    UpdateGroupDetails1(group);
                    return new ResponseDto<bool>()
                    {
                        DisplayMessage = $"Successfully added to {group.SaveName} group",
                        StatusCode = 200,
                        Result = true
                    };
                }

                return new ResponseDto<bool>()
                {
                    DisplayMessage = $"Unable to add you to {group.SaveName}",
                    StatusCode = 404,
                    Result = false
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while joining group savings");
                return new ResponseDto<bool>()
                {
                    DisplayMessage = "An error occurred while processing your request",
                    StatusCode = 500,
                    Result = false
                };
            }
        }

        private void UpdateGroupDetails1(Group group)
        {
            group.MemberCount++;
            _unitOfWork.GroupRepository.UpdateAsync(group);
            _unitOfWork.SaveChanges();
        }


        private void UpdateGroupDetails(Group group)
        {
            group.ActualStartDate = DateTime.UtcNow.Date;
            group.NextRunTime = DateTime.Today;
            group.GroupStatus = GroupStatus.OnGoing;

            switch (group.Schedule)
            {
                case FundFrequency.Daily:
                    group.ExpectedEndDate = DateTime.UtcNow.AddDays(6);
                    break;
                case FundFrequency.Weekly:
                    group.ExpectedEndDate = DateTime.UtcNow.AddDays(35);
                    break;
                case FundFrequency.Monthly:                  
                    group.ExpectedEndDate = DateTime.UtcNow.AddDays(155);
                    break;
                default:
                    break;
            }

            //group.MemberCount++;
            _unitOfWork.GroupRepository.UpdateAsync(group);
            _unitOfWork.SaveChanges();
        }

    }
}
