// ==========================================================
// Interface: IRegistrationVerificationRepository
// Purpose : Handles database access for DDO and HOO workflow
// Layer   : Application
// Architecture : Clean Architecture
// ==========================================================

using WBHealthScheme.Domain.Entities;

namespace WBHealthScheme.Application.Interfaces.Repositories;

public interface IRegistrationVerificationRepository
{
    // ======================================================
    // GET APPLICATIONS BY STATUS
    // ======================================================

    /// <summary>
    /// Returns applications filtered by workflow status
    /// Example: Submitted, DdoApproved
    /// </summary>
    Task<List<WbhsApplicationIdEmpOnline>> GetSubmittedApplicationsAsync();

    Task<List<WbhsApplicationIdEmpOnline>> GetDdoApprovedApplicationsAsync();


    /// <summary>
    /// Returns single application by ID
    /// </summary>
    Task<WbhsApplicationIdEmpOnline?> GetApplicationAsync(string appId);


    // ======================================================
    // PERSONAL DETAILS
    // ======================================================

    Task<EmployeeBasicInfo?> GetPersonalAsync(string appId);


    // ======================================================
    // UPDATE OPERATIONS
    // ======================================================

    Task UpdateApplicationAsync(WbhsApplicationIdEmpOnline entity);

    Task UpdatePersonalAsync(EmployeeBasicInfo entity);
}