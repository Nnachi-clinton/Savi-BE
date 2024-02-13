using Microsoft.AspNetCore.Http;
using Savi.Core.DTO;
using Savi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savi.Core.IServices
{
    public interface IGroupSavings
    {
        ResponseDto<List<GroupDTO>> GetExploreGroupSavingGroups();
        ResponseDto<GroupDTO> GetExploreGroupSavingDetails(string groupId);
        ResponseDto<GroupDTO> GetGroupSavingAccountDetails(string groupId);
        ResponseDto<List<GroupDTO>> GetListOfActiveSavingsGroups();
        Task<ResponseDto<string>> CreateSavingsGroup(GroupDTO2 dto);
        Task<ResponseDto<int>> GetTotalSavingsGroupCountAsync();
    }
}
