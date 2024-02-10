using Savi.Core.DTO;

namespace Savi.Core.IServices
{
    public interface IFundingAnalyticsBackgroundServices
    {
        public Task<ResponseDto<string>> SWCFunding();
    }
}
