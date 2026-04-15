using WBHealthScheme.Application.DTOs;
using WBHealthScheme.Domain.Common;

namespace WBHealthScheme.Application.Interfaces.Services;

/// <summary>
/// Service contract for Registration workflow.
/// </summary>
public interface IEmployeeRegistrationService
{
    // ======================================================
    // STEP 1 - Application Creation
    // ======================================================

    Task<CreateApplicationResponse> CreateApplicationAsync(
        CreateApplicationRequest request);

    // ======================================================
    // STEP 1b - District & DOB (shown after GPF generated)
    // ======================================================

    Task<ApiResponse<object>> InitiateRegistrationAsync(
        InitiateRegistrationRequest request);

    // ======================================================
    // STEP 2 - Personal Details
    // ======================================================

    Task<ApiResponse<object>> AddPersonalDetailsAsync(
        CreatePersonalDetailsRequest request);

    // ======================================================
    // STEP 3 - Office Details
    // ======================================================

    Task<ApiResponse<object>> AddOfficeDetailsAsync(
        CreateOfficeDetailsRequest request);

    // ======================================================
    // STEP 4 - Family Member
    // ======================================================

    Task<ApiResponse<object>> AddFamilyMemberAsync(
        CreateFamilyMemberRequest request);

    // ======================================================
    // STEP 5 - CCA Details
    // ======================================================

    Task<ApiResponse<object>> AddCcaDetailsAsync(
        CreateCcaDetailsRequest request);

    // ======================================================
    // FINAL STEP - Submit Application
    // ======================================================

    Task<ApiResponse<object>> SubmitApplicationAsync(
        string applicationId);


    // ======================================================
    // UPDATE METHODS (PATCH APIs)
    // Used when employee edits application after rejection
    // ======================================================

    // ------------------------------------------------------
    // UPDATE PERSONAL DETAILS
    // ------------------------------------------------------

    Task<ApiResponse<object>> UpdatePersonalDetailsAsync(
        UpdatePersonalDetailsRequest request);


    // ------------------------------------------------------
    // UPDATE OFFICE DETAILS
    // ------------------------------------------------------

    Task<ApiResponse<object>> UpdateOfficeDetailsAsync(
        UpdateOfficeDetailsRequest request);


    // ------------------------------------------------------
    // UPDATE FAMILY MEMBER
    // ------------------------------------------------------

    Task<ApiResponse<object>> UpdateFamilyMemberAsync(
        UpdateFamilyMemberRequest request);


    // ------------------------------------------------------
    // UPDATE CCA DETAILS
    // ------------------------------------------------------

    Task<ApiResponse<object>> UpdateCcaDetailsAsync(
        UpdateCcaDetailsRequest request);


    /// <summary>
    /// Upload family photo & signature
    /// </summary>
    Task UploadFamilyPhotoAsync(UploadFamilyPhotoCommand request);

    // ======================================================
    // GET APPLICATION DETAILS
    // ======================================================

    Task<ApplicationDetailsResponse> GetApplicationDetailsAsync(string appId);
}