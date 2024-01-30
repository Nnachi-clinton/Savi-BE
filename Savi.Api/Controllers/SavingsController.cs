using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Savi.Core.DTO;
using Savi.Core.IServices;
using Savi.Model.Entities;

namespace Savi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavingsController : ControllerBase
    {
        private readonly IPersonalSavings _personalSavings;
        private readonly IMapper _mapper;
        public SavingsController(IPersonalSavings personalSavings, IMapper mapper)
        {
            _personalSavings = personalSavings;
            _mapper = mapper;
        }

        [HttpPost("SetGoal")]
        public async Task<IActionResult> AddMoreGoals([FromForm] PersonalSavingsDTO saving, string userId)
        {
            var response = await _personalSavings.SetPersonal_Savings_Target(saving, userId);
            if (response.StatusCode == 200)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("listAllGoals/{UserId}")]
        public async Task<IActionResult> GetAllGoals(string UserId)
        {
            var response = await _personalSavings.Get_ListOf_All_UserTargets(UserId);
            if (response.StatusCode == 200)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
