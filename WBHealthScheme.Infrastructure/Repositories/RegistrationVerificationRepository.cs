using Microsoft.EntityFrameworkCore;
using WBHealthScheme.Application.Interfaces.Repositories;
using WBHealthScheme.Domain.Entities;
using WBHealthScheme.Infrastructure.Persistence;

namespace WBHealthScheme.Infrastructure.Repositories;

public class RegistrationVerificationRepository : IRegistrationVerificationRepository
{
    private readonly WBHSDbContext _context;

    public RegistrationVerificationRepository(WBHSDbContext context)
    {
        _context = context;
    }

    // Applications where CCA exists (all steps done) but DDO not yet verified
    public async Task<List<WbhsApplicationIdEmpOnline>> GetSubmittedApplicationsAsync()
    {
        var ddoVerifiedAppIds = await _context.EmployeeBasicInfos
            .Where(x => x.DdoVerifyDate != null && x.IsExists == "Y")
            .Select(x => x.AppId)
            .ToListAsync();

        var ccaAppIds = await _context.EmployeeCcaLocations
            .Where(x => x.IsExists == "Y")
            .Select(x => x.AppId)
            .ToListAsync();

        var submittedAppIds = ccaAppIds.Except(ddoVerifiedAppIds).ToList();

        return await _context.EmployeeApplications
            .Where(x => submittedAppIds.Contains(x.AppId) && x.IsExists == "Y")
            .ToListAsync();
    }

    // Applications where DDO has verified (DdoVerifyDate set and not MinValue)
    public async Task<List<WbhsApplicationIdEmpOnline>> GetDdoApprovedApplicationsAsync()
    {
        var approvedAppIds = await _context.EmployeeBasicInfos
            .Where(x => x.DdoVerifyDate != null
                     && x.DdoVerifyDate != DateTime.MinValue
                     && x.ApproveUser == null
                     && x.IsExists == "Y")
            .Select(x => x.AppId)
            .ToListAsync();

        return await _context.EmployeeApplications
            .Where(x => approvedAppIds.Contains(x.AppId) && x.IsExists == "Y")
            .ToListAsync();
    }

    public async Task<WbhsApplicationIdEmpOnline?> GetApplicationAsync(string appId)
    {
        return await _context.EmployeeApplications
            .FirstOrDefaultAsync(x => x.AppId == appId);
    }

    public async Task<EmployeeBasicInfo?> GetPersonalAsync(string appId)
    {
        return await _context.EmployeeBasicInfos
            .FirstOrDefaultAsync(x => x.AppId == appId);
    }

    public async Task UpdateApplicationAsync(WbhsApplicationIdEmpOnline entity)
    {
        _context.EmployeeApplications.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePersonalAsync(EmployeeBasicInfo entity)
    {
        _context.EmployeeBasicInfos.Update(entity);
        await _context.SaveChangesAsync();
    }
}