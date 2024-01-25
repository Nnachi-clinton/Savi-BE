using Microsoft.AspNetCore.Mvc;
using Savi.Core.IServices;

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
        [Route("api/paystack/verify/{referenceCode}")]
        public async Task<IActionResult> VerifyPayment(string referenceCode)
        {
            var result = await _walletServices.VerifyTransaction(referenceCode);

            return Ok(result);
        }
    }
}
