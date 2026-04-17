using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WBHealthScheme.Application.Dtos;
using WBHealthScheme.Application.Interfaces;
using WBHealthScheme.Domain.Common;
namespace WBHealthScheme.Api.Controllers
{
    [ApiController]
    [Route("api/v1/beneficiary-auth")]
    public class BeneficiaryAuthenticationController : ControllerBase
    {
        private readonly IBeneficiaryAuthenticationService _service;
        public BeneficiaryAuthenticationController(IBeneficiaryAuthenticationService service)
        {
            _service = service;
        }
        [HttpGet("mobile/{mobileNumber}")]
        public async Task<IActionResult> GetByMobile(string mobileNumber)
        {
            var result = await
            _service.GetBeneficiaryByMobileAsync(mobileNumber);

            //return Ok(new ApiResponse<List<BeneficiaryAuthenticationResponse>>
            //{
            //    Success = true,
            //    Message = "Beneficiary fetched successfully",
            //    Status = "200",
            //    Data = result,
            //    Errors = null
            //});
            return Ok(ApiResponse<List<BeneficiaryAuthenticationResponse>>
                .Ok(result, "Beneficiary fetched successfully"));
        }

        [HttpGet("APPID/{enrollmentid}")]
        public async Task<IActionResult> GetwardByappid(string enrollmentid)
    {
    var result = await
    _service.GetwardByappAsync(enrollmentid);

    //return Ok(new ApiResponse<List<BeneficiaryAuthenticationResponse>>
    //{
    //    Success = true,
    //    Message = "Beneficiary fetched successfully",
    //    Status = "200",
    //    Data = result,
    //    Errors = null
    //});
    return Ok(ApiResponse<List<Beneiciary_ward_resp_broto>>
        .Ok(result, "Enrollment fetched successfully"));
}
    }
}
