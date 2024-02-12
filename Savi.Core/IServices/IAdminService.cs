using Savi.Core.DTO;
using Savi.Model;

namespace Savi.Core.IServices
{
    public interface IAdminService
    {
        ApiResponse<GroupDTO> GetGroupSavingById (string groupId);
        Task<ApiResponse<GroupTransactionDto>> GetGroupTransactionsAsync(int page, int perPage);
    }
}
