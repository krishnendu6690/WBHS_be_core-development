using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WBHealthScheme.Application.DTOs;
using WBHealthScheme.Application.Interfaces.Services;
using WBHealthScheme.API.Models;

namespace WBHealthScheme.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/registration")]
public class RegistrationController : ControllerBase
{
    private readonly IEmployeeRegistrationService _registrationService;

    public RegistrationController(
        IEmployeeRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }

    // ------------------------------------------------------
    // API: Generate Application ID
    // ------------------------------------------------------
    [HttpPost("create-application")]
    public async Task<IActionResult> CreateApplication(CreateApplicationRequest request)
    {
        var result = await _registrationService.CreateApplicationAsync(request);

        return Ok(result);
    }

    //add personal details

    // STEP 1b - District & DOB
    [HttpPost("initiate")]
    public async Task<IActionResult> InitiateRegistration(
        [FromBody] InitiateRegistrationRequest request)
    {
        var response = await _registrationService.InitiateRegistrationAsync(request);
        return Ok(response);
    }

    [HttpPost("personal-details")]
    public async Task<IActionResult> SavePersonalDetails(
        [FromBody] CreatePersonalDetailsRequest request)
    {
        var response = await _registrationService
            .AddPersonalDetailsAsync(request);

        return Ok(response);
    }

    // ==========================================================
    // STEP 3 - Office Details
    // ==========================================================
    [HttpPost("office-details")]
    public async Task<IActionResult> SaveOfficeDetails(
        [FromBody] CreateOfficeDetailsRequest request)
    {
        var response = await _registrationService
            .AddOfficeDetailsAsync(request);

        return Ok(response);
    }
    // ==========================================================
    // STEP 3 - family member Details
    // ==========================================================

    [HttpPost("family-member")]
    public async Task<IActionResult> AddFamilyMember(
    [FromBody] CreateFamilyMemberRequest request)
    {
        var response = await _registrationService
            .AddFamilyMemberAsync(request);

        return Ok(response);
    }
    // ==========================================================
    // STEP 4- cca  Details
    // ==========================================================


    [HttpPost("cca-details")]
    public async Task<IActionResult> AddCcaDetails(
    [FromBody] CreateCcaDetailsRequest request)
    {
        var response = await _registrationService
            .AddCcaDetailsAsync(request);

        return Ok(response);
    }

    // ======================================================
    // FINAL STEP - Submit Application
    // ======================================================
    //[HttpPost("submit/{applicationId}")]
    //public async Task<IActionResult> SubmitApplication(
    // string applicationId)
    // {
    //  var response = await _registrationService
    //   .SubmitApplicationAsync(applicationId);

    // return Ok(response);
    // }

    [HttpPost("submit")]
    public async Task<IActionResult> SubmitApplication(
    [FromQuery] string applicationId)
    {
        var response = await _registrationService
            .SubmitApplicationAsync(applicationId);

        return Ok(response);
    }

    // ======================================================
    // UPDATE PERSONAL DETAILS
    // Used when employee edits after rejection
    // ======================================================
    // ======================================================
    // PATCH PERSONAL DETAILS (PARTIAL UPDATE)
    // ======================================================
    [HttpPatch("personal")]
    public async Task<IActionResult> UpdatePersonalDetails(
        [FromBody] UpdatePersonalDetailsRequest request)
    {
        var result = await _registrationService.UpdatePersonalDetailsAsync(request);

        return Ok(result);
    }

    // ======================================================
    // PATCH OFFICE DETAILS
    // ======================================================

    [HttpPatch("office")]
    public async Task<IActionResult> UpdateOfficeDetails(
        [FromBody] UpdateOfficeDetailsRequest request)
    {
        var result = await _registrationService
            .UpdateOfficeDetailsAsync(request);

        return Ok(result);
    }


    // ======================================================
    // PATCH FAMILY MEMBER
    // ======================================================

    [HttpPatch("family")]
    public async Task<IActionResult> UpdateFamilyMember(
        [FromBody] UpdateFamilyMemberRequest request)
    {
        var result = await _registrationService
            .UpdateFamilyMemberAsync(request);

        return Ok(result);
    }


    // ======================================================
    // PATCH CCA DETAILS
    // ======================================================

    [HttpPatch("cca")]
    public async Task<IActionResult> UpdateCcaDetails(
        [FromBody] UpdateCcaDetailsRequest request)
    {
        var result = await _registrationService
            .UpdateCcaDetailsAsync(request);

        return Ok(result);
    }

    /// <summary>
    /// Upload family photo and signature
    /// </summary>
    [HttpPost("family/upload-photo-signature")]
    public async Task<IActionResult> UploadFamilyPhoto(
       [FromForm] UploadFamilyPhotoRequest request)
    {
        // Convert Photo
        byte[] photoBytes;
        using (var ms = new MemoryStream())
        {
            await request.Photo.CopyToAsync(ms);
            photoBytes = ms.ToArray();
        }

        // Convert Signature
        byte[] signBytes;
        using (var ms = new MemoryStream())
        {
            await request.Signature.CopyToAsync(ms);
            signBytes = ms.ToArray();
        }

        var command = new UploadFamilyPhotoCommand
        {
            AppId = request.AppId,
            IdNo = request.IdNo,
            PhotoBytes = photoBytes,
            SignatureBytes = signBytes,
            PhotoFileName = request.Photo.FileName,
            SignatureFileName = request.Signature.FileName
        };

        await _registrationService.UploadFamilyPhotoAsync(command);


        return Ok(new
        {
            success = true,
            message = "Family photo and signature uploaded successfully"
        });
    }

    /// <summary>
    /// Get complete application details
    /// Used by Employee / DDO / HOO verification screens
    /// </summary>

    /* [HttpGet("application/{*appId}")]
     public async Task<IActionResult> GetApplicationDetails(string appId)
     {
         var result = await _registrationService.GetApplicationDetailsAsync(appId);

         return Ok(new
         {
             success = true,
             data = result
         });
     }*/

    // ==========================================================
    // Controller: RegistrationController
    // ==========================================================

    [HttpGet("application/{*appId}")]
    public async Task<IActionResult> GetApplicationDetails(string appId)
    {
        // Decode URL encoded value
        appId = Uri.UnescapeDataString(appId);

        var result = await _registrationService.GetApplicationDetailsAsync(appId);

        return Ok(new
        {
            success = true,
            message = "Application fetch successfully",
            data = result
        });
    }
}

