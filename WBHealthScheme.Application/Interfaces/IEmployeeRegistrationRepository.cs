// ==========================================================
// Interface: IEmployeeRegistrationRepository
// Purpose : Repository contract for Employee Registration
// Layer   : Application
// Standard: Clean Architecture
// ==========================================================

using WBHealthScheme.Domain.Entities;

namespace WBHealthScheme.Application.Interfaces.Repositories;

public interface IEmployeeRegistrationRepository
{
    

    // ======================================================
    // APPLICATION MODULE
    // ======================================================

    // ==========================================================
    // Repository Contract for Application Module
    // ==========================================================

    Task<string?> GetLastApplicationIdAsync();

    Task SaveApplicationAsync(WbhsApplicationIdEmpOnline entity);


    Task<WbhsApplicationIdEmpOnline?> GetApplicationAsync(string applicationId);
    Task UpdateApplicationAsync(WbhsApplicationIdEmpOnline entity);

    // ======================================================
    // PERSONAL DETAILS MODULE
    // ======================================================

    Task AddPersonalDetailsAsync(EmployeeBasicInfo entity);

    Task<EmployeeBasicInfo?> GetPersonalDetailsByAppIdAsync(string appId);

    Task UpdatePersonalDetailsAsync(EmployeeBasicInfo entity);

    Task<bool> PersonalDetailsExistsAsync(string appId);

    // ======================================================
    // OFFICE DETAILS MODULE
    // ======================================================

    Task AddOfficeDetailsAsync(EmployeeOfficeLink entity);

    Task<EmployeeOfficeLink?> GetOfficeDetailsByAppIdAsync(string appId);

    Task UpdateOfficeDetailsAsync(EmployeeOfficeLink entity);

    Task<bool> OfficeDetailsExistsAsync(string appId);

    // ======================================================
    // FAMILY MODULE
    // ======================================================

    Task AddFamilyMemberAsync(EmployeeFamilyMember entity);

   
    // CHECK FAMILY MEMBER EXISTS
    
    Task<bool> FamilyMemberExistsAsync(string appId, string idNo);

    Task<EmployeeFamilyMember?> GetFamilyMemberAsync(string appId, string idNo);

    Task UpdateFamilyMemberAsync(EmployeeFamilyMember entity);

    Task<bool> FamilyDetailsExistsAsync(string appId);

    // ======================================================
    // CCA MODULE
    // ======================================================

    Task AddCcaDetailsAsync(EmployeeCcaLocation entity);

    Task<EmployeeCcaLocation?> GetCcaDetailsByAppIdAsync(string appId);

    Task UpdateCcaDetailsAsync(EmployeeCcaLocation entity);

    Task<bool> CcaDetailsExistsAsync(string appId);

    /// <summary>
    /// Insert or update family photo & signature
    /// </summary>
    Task SaveFamilyPhotoAsync(WbhsFamilyPhotoSignature entity);

    /// <summary>
    /// Check if photo already exists
    /// </summary>
    //Task<WbhsFamilyPhotoSignature> GetFamilyPhotoAsync(string appId, string idNo);
    Task<WbhsFamilyPhotoSignature?> GetFamilyPhotoAsync(string appId, string idNo);

    // ======================================================
    // APPLICATION DETAILS
    // ======================================================

    Task<List<EmployeeFamilyMember>> GetFamilyMembersByAppIdAsync(string appId);
}