using AutoMapper;
using Savi.Core.DTO;
using Savi.Core.IServices;
using Savi.Data.Repositories.Interface;
using Savi.Model.Enums;

namespace Savi.Core.Services
{
    public class GroupSavings : IGroupSavings
    {
        private readonly IMapper _IMapper;
        private readonly IUnitOfWork _unitOfWork;

        public GroupSavings(IMapper iMapper, IUnitOfWork unitOfWork)
        {
            _IMapper = iMapper;
            _unitOfWork = unitOfWork;
        }

        public ResponseDto<List<GroupDTO>> GetExploreGroupSavingGroups()
        {
            var response = new ResponseDto<List<GroupDTO>>();

            try
            {
                var exploreGroupSavingGroups =  _unitOfWork.GroupRepository.GetAll();
                var waitingGroups = exploreGroupSavingGroups.Where(groupDto => groupDto.GroupStatus == GroupStatus.Waiting).ToList();
                if (waitingGroups.Count > 0)
                {
                    var mappedExploreGroups = _IMapper.Map<List<GroupDTO>>(exploreGroupSavingGroups);
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
                var exploreGroupSavingGroups = _unitOfWork.GroupRepository.GetById(groupId);
                ArgumentNullException.ThrowIfNull(exploreGroupSavingGroups);
                if (exploreGroupSavingGroups.GroupStatus == GroupStatus.Waiting)
                {
                    var mappedExploreGroup = _IMapper.Map<GroupDTO>(exploreGroupSavingGroups);
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
                        DisplayMessage = "No explore savings group accounts found",
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


    }
}
    

