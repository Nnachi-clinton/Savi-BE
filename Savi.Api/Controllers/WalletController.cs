using Microsoft.AspNetCore.Mvc;
using Savi.Core.IServices;
using Savi.Core.Services;

namespace Savi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletServices _walletServices;

        public WalletController(IWalletServices walletServices)
        {
            _walletServices = walletServices;
        }

        [HttpGet]
        [Route("api/paystack/verify/{referenceCode}/{userId}")]
        public async Task<IActionResult> VerifyPayment(string referenceCode, string userId)
        {
            var result = await _walletServices.VerifyTransaction(referenceCode, userId);

            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserByIdAsync(string userId)
        {
            var response =  _walletServices.GetUserWalletAsync(userId);
            return Ok(response);
        }
    }
}
