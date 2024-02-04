using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Savi.Core.IServices;

namespace Savi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupSavingsController : ControllerBase
    {
        private readonly IGroupSavings _groupSavings;
        private readonly IMapper _mapper;

        public GroupSavingsController(IGroupSavings groupSavings, IMapper mapper)
        {
            _groupSavings = groupSavings;
            _mapper = mapper;
        }

        [HttpGet("ExploreGroups")]
        public IActionResult GetExploreGroupSavingGroups()
        {
            var response = _groupSavings.GetExploreGroupSavingGroups();

            return response.StatusCode switch
            {
                200 => Ok(response),
                404 => NotFound(response),
                500 => StatusCode(500, response),
                _ => BadRequest(response)
            };
        }
    }
}
