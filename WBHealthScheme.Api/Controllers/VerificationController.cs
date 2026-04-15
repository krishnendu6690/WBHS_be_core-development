// ==========================================================
// Controller: VerificationController
// Purpose   : Handles DDO & HOO verification workflow
// Layer     : API
// Standard  : Enterprise Clean Architecture
//
// Workflow
// ----------------------------------------------------------
// Employee Submit Application
//          ↓
// DDO Verification
//          ↓
// If Approved → Goes to HOO
// If Rejected → Workflow Ends
//          ↓
// HOO Verification
//          ↓
// Final Approval
//
// NOTE
// ----------------------------------------------------------
// Authentication (JWT) can be added later using:
//
// [Authorize(Roles="DDO")]
// [Authorize(Roles="HOO")]
//
// without changing controller logic.
//
// ==========================================================

using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WBHealthScheme.Application.DTOs.Ddo;
using WBHealthScheme.Application.DTOs.Hoo;
using WBHealthScheme.Application.Interfaces.Services;

namespace WBHealthScheme.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/verification")]
public class VerificationController : ControllerBase
{
    // ======================================================
    // SERVICES
    // ======================================================

    private readonly IDdoVerificationService _ddoService;
    private readonly IHooVerificationService _hooService;

    public VerificationController(
        IDdoVerificationService ddoService,
        IHooVerificationService hooService)
    {
        _ddoService = ddoService;
        _hooService = hooService;
    }

    // ======================================================
    // DDO VERIFICATION MODULE
    // ======================================================

    /// <summary>
    /// Get all applications submitted by employees
    /// which are waiting for DDO verification.
    /// </summary>
    [HttpGet("ddo/applications")]
    public async Task<IActionResult> GetApplicationsForDdo()
    {
        var result = await _ddoService.GetSubmittedApplicationsAsync();

        return Ok(result);
    }


    /// <summary>
    /// DDO verifies and approves an employee application.
    /// After approval, application moves to HOO verification.
    /// </summary>
    [HttpPost("ddo/verify")]
    public async Task<IActionResult> VerifyByDdo(
        [FromBody] DdoVerifyRequest request)
    {
        await _ddoService.VerifyApplicationAsync(request);

        return Ok(new
        {
            success = true,
            message = "Application verified successfully by DDO"
        });
    }


    /// <summary>
    /// DDO rejects an application.
    /// Rejected applications will NOT go to HOO.
    /// </summary>
    [HttpPost("ddo/reject")]
    public async Task<IActionResult> RejectByDdo(
        [FromBody] DdoRejectRequest request)
    {
        await _ddoService.RejectApplicationAsync(request);

        return Ok(new
        {
            success = true,
            message = "Application rejected by DDO"
        });
    }


    // ======================================================
    // HOO VERIFICATION MODULE
    // ======================================================

    /// <summary>
    /// Returns applications that were verified by DDO
    /// and are pending for HOO approval.
    /// </summary>
    [HttpGet("hoo/applications")]
    public async Task<IActionResult> GetApplicationsForHoo()
    {
        var result = await _hooService.GetDdoVerifiedApplicationsAsync();

        return Ok(result);
    }


    /// <summary>
    /// HOO approves application.
    /// This is final approval in registration workflow.
    /// </summary>
    [HttpPost("hoo/approve")]
    public async Task<IActionResult> ApproveByHoo(
        [FromBody] HooApproveRequest request)
    {
        await _hooService.ApproveApplicationAsync(request);

        return Ok(new
        {
            success = true,
            message = "Application approved by HOO"
        });
    }


    /// <summary>
    /// HOO rejects application after DDO approval.
    /// Application status becomes HOORejected.
    /// </summary>
    [HttpPost("hoo/reject")]
    public async Task<IActionResult> RejectByHoo(
        [FromBody] HooApproveRequest request)
    {
        await _hooService.RejectApplicationAsync(request);

        return Ok(new
        {
            success = true,
            message = "Application rejected by HOO"
        });
    }
}