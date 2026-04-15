// ==========================================================
// Interface: IDdoVerificationService
// Purpose : Contract for DDO verification workflow
// Layer   : Application
// ==========================================================

using WBHealthScheme.Application.DTOs.Ddo;
using WBHealthScheme.Domain.Entities;

namespace WBHealthScheme.Application.Interfaces.Services;

public interface IDdoVerificationService
{
    // ======================================================
    // GET SUBMITTED APPLICATIONS
    // Used by DDO dashboard
    // ======================================================

    Task<List<DdoApplicationListDto>> GetSubmittedApplicationsAsync();


    // ======================================================
    // VERIFY APPLICATION
    // ======================================================

    Task VerifyApplicationAsync(DdoVerifyRequest request);


    // ======================================================
    // REJECT APPLICATION
    // ======================================================

    Task RejectApplicationAsync(DdoRejectRequest request);
}