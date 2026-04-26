using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WBHealthScheme.Application.dtos;
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

        [HttpGet("univ/{unique-id}")]
        public async Task<IActionResult> GetByUniqueId(string uniqueId)
        {
            var result = await
            _service.GetBeneficiaryByUniqueIdAsync(uniqueId);

            return Ok(ApiResponse<List<UnivBeneficiaryAuthenticationResponse>>
                .Ok(result, "Beneficiary fetched successfully"));
        }

        [HttpGet("govtemp/{hrms-id}")]
        public async Task<IActionResult> GetwardByappid(string hrmsid)
        {
            var result = await
            _service.GetWardByAppIdAsync(hrmsid);

            return Ok(ApiResponse<List<BeneficiaryWardRespBroto>>
            .Ok(result, "Enrollment fetched successfully"));
        return Ok(ApiResponse<List<BeneficiaryWardRespBroto>>
        .Ok(result, "Enrollment fetched successfully"));
        
        }


        [HttpGet("clg/{hrms-id}")]
        public async Task<IActionResult> GetByHrmsId(string hrmsId)
        {
            var result = await
            _service.GetBeneficiaryByHrmsIdClgAsync(hrmsId);

            return Ok(ApiResponse<List<ClgBeneficiaryAuthenticationResponse>>
                .Ok(result, "Beneficiary fetched successfully"));
        }

        [HttpGet("pnhytEmp/{iosms-id}")]
        public async Task<IActionResult> GetByIosmsId(string iosmsId)
        {
            var result = await
            _service.GetBeneficiaryByIosmsIdAsync(iosmsId);

            return Ok(ApiResponse<List<PnhytEmpBeneficiaryAuthenticationResponse>>
                .Ok(result, "Beneficiary fetched successfully"));
        }

        [HttpGet("pnhytPen/{*app-id}")]
        public async Task<IActionResult> GetByPnhytPenAppId(string appId)
        {
            var result = await
            _service.GetBeneficiaryPnhytPenByAppIdAsync(appId);

            return Ok(ApiResponse<List<PnhytPenBeneficiaryAuthenticationResponse>>
                .Ok(result, "Beneficiary fetched successfully"));
        }

        [HttpGet("govtEmpPen/{app-id}")]
        public async Task<IActionResult> GetbyAppliID(string appId)
        {
            var result = await _service.GetBeneficiaryEmpPenByAppIdAsync(appId);

            return Ok(ApiResponse<List<EmpPenBeneficiaryAuthenticationResponse>>
            .Ok(result, "Enrollment fetched successfully"));
        }
        
        [HttpGet("mobileNumber/{mob-number}")]
        public async Task<IActionResult> GetByMobileAll(string mobNumber)
        {
            var result = await
            _service.GetAllBeneficiaryByMobileAsync(mobNumber);
            
            return Ok(ApiResponse<List<AllBeneficiaryAuthenticationResponseByMobileNo>>
                .Ok(result, "Beneficiary fetched successfully"));
        }

    }
}
