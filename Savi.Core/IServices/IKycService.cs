using Microsoft.AspNetCore.Http;
using Savi.Core.DTO;
using Savi.Model;

namespace Savi.Core.IServices
{
    public interface IKycService
    {
        Task<ApiResponse<KycRequestDto>> GetKycByIdAsync(string id);
        Task<ApiResponse<GetAllKycsDto>> GetKycsByPaginationAsync(int page, int perPage);
        Task<ApiResponse<KycResponseDto>> AddKycAsync(string userId, KycRequestDto kycRequestDto);
        Task<ApiResponse<KycResponseDto>> UpdateKycAsync(string kycId, UpdateKycDto updateKycDto);
        Task<ApiResponse<bool>> DeleteKycByIdAsync (string kycId);
    }
}
