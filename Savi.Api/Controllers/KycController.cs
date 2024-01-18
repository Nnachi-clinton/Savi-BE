﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Savi.Core.DTO;
using Savi.Core.IServices;
using Savi.Model;

namespace Savi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KycController : ControllerBase
    {
        private readonly IKycService _kycService;

        public KycController(IKycService kycService)
        {
            _kycService = kycService;
        }

        [HttpPost("addKyc")]
        public async Task<IActionResult> AddKycAsync(string userId,[FromForm] KycRequestDto kycRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<string>(false, "Invalid model state.", StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
            }
            return Ok(await _kycService.AddKycAsync(userId, kycRequestDto));
        }

        [HttpGet("kycId")]
        public async Task<IActionResult> GetKycByIdAsync(string userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<string>(false, "Invalid model state.", StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
            }
            return Ok(await _kycService.GetKycByIdAsync(userId));
        }

        [HttpGet("get-kycs")]
        public async Task<IActionResult> GetAllKycs(int page, int perPage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<string>(false, "Invalid model state.", StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
            }
            return Ok(await _kycService.GetKycsByPaginationAsync(page, perPage));
        }

        [HttpPut("update/{kycId}")]
        public async Task<IActionResult> UpdateKycAsync(string kycId, [FromBody] UpdateKycDto updateKycDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<string>(false, "Invalid model state.", StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
            }
            return Ok(await _kycService.UpdateKycAsync(kycId, updateKycDto));
        }

        [HttpDelete("delete/{kycId}")]
        public async Task<IActionResult> DeleteKycAsync(string kycId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<string>(false, "Invalid model state.", StatusCodes.Status400BadRequest, ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
            }
            return Ok(await _kycService.DeleteKycByIdAsync(kycId));
        }
    }
}
