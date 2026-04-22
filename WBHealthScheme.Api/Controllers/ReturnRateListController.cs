using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WBHealthScheme.Application.Dtos;
using WBHealthScheme.Application.Interfaces;
using WBHealthScheme.Domain.Common;
namespace WBHealthScheme.Api.Controllers
{
    [ApiController]
    [Route("api/v1/Ratelist-Fetch")]

    public class ReturnRatelistController : ControllerBase
    {
        private readonly IRatelistReturnService _service;

        public ReturnRatelistController(IRatelistReturnService service)
        {
            _service = service;
        }

        [HttpGet("RATENAME/{Description}")]

        public async Task<IActionResult> GetRatelistByName(string Description)
        {
            var result = await _service.GetRatelistByNameAsync(Description);

            return Ok(ApiResponse<List<ReturnRatelistResponse>>.Ok(result, "Details Fetched Successfully"));
        }
    }
}