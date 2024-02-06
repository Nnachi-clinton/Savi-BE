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
    }
}
