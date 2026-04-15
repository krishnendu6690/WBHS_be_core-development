// ==========================================================
// Repository: EmployeeRegistrationRepository
// Purpose : Implements Registration persistence logic
// Layer   : Infrastructure
// Standard: Enterprise Clean Architecture
// ==========================================================

using Microsoft.EntityFrameworkCore;
using WBHealthScheme.Application.Interfaces.Repositories;
using WBHealthScheme.Domain.Entities;
using WBHealthScheme.Domain.Enums;
using WBHealthScheme.Infrastructure.Persistence;

namespace WBHealthScheme.Infrastructure.Repositories;

public class EmployeeRegistrationRepository : IEmployeeRegistrationRepository
{
    private readonly WBHSDbContext _context;

    public EmployeeRegistrationRepository(WBHSDbContext context)
    {
        _context = context;
    }





    // ======================================================
    // APPLICATION MODULE
    // ======================================================

    // ======================================================
    // GET APPLICATION
    // ======================================================
    public async Task<WbhsApplicationIdEmpOnline?> GetApplicationAsync(string applicationId)
    {
        return await _context.EmployeeApplications
            .FirstOrDefaultAsync(x => x.AppId == applicationId);
    }

    // ======================================================
    // UPDATE APPLICATION
    // ======================================================
    public async Task UpdateApplicationAsync(WbhsApplicationIdEmpOnline entity)
    {
        _context.EmployeeApplications.Update(entity);
        await _context.SaveChangesAsync();
    }

    // ------------------------------------------------------
    // Get Last Application ID for given Location
    // ------------------------------------------------------
    public async Task<string?> GetLastApplicationIdAsync()
    {
        return await _context.EmployeeApplications
            .Where(x => x.AppId.StartsWith("WB/EMP/"))
            .OrderByDescending(x => x.AppIdTime)
            .Select(x => x.AppId)
            .FirstOrDefaultAsync();
    }

    // ------------------------------------------------------
    // Save Application Record
    // ------------------------------------------------------
    public async Task SaveApplicationAsync(WbhsApplicationIdEmpOnline entity)
    {
        await _context.EmployeeApplications.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    // ======================================================
    // PERSONAL DETAILS MODULE
    // ======================================================

    public async Task AddPersonalDetailsAsync(EmployeeBasicInfo entity)
    {
        _context.EmployeeBasicInfos.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> PersonalDetailsExistsAsync(string appId)
    {
        return await _context.EmployeeBasicInfos
            .AnyAsync(x => x.AppId == appId && x.IsExists == "Y");
    }

    // ======================================================
    // GET PERSONAL DETAILS
    // ======================================================

    public async Task<EmployeeBasicInfo?> GetPersonalDetailsByAppIdAsync(string appId)
    {
        return await _context.EmployeeBasicInfos
            .FirstOrDefaultAsync(x => x.AppId == appId);
    }

    public async Task UpdatePersonalDetailsAsync(EmployeeBasicInfo entity)
    {
        _context.EmployeeBasicInfos.Update(entity);
        await _context.SaveChangesAsync();
    }

    // ======================================================
    // OFFICE DETAILS MODULE
    // ======================================================

    public async Task AddOfficeDetailsAsync(EmployeeOfficeLink entity)
    {
        _context.EmployeeOfficeLinks.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> OfficeDetailsExistsAsync(string appId)
    {
        return await _context.EmployeeOfficeLinks
            .AnyAsync(x => x.AppId == appId && x.IsExists == "Y");
    }

    public async Task<EmployeeOfficeLink?> GetOfficeDetailsByAppIdAsync(string appId)
    {
        return await _context.EmployeeOfficeLinks
            .FirstOrDefaultAsync(x => x.AppId == appId);
    }

    public async Task UpdateOfficeDetailsAsync(EmployeeOfficeLink entity)
    {
        _context.EmployeeOfficeLinks.Update(entity);
        await _context.SaveChangesAsync();
    }

    // ======================================================
    // FAMILY MODULE
    // ======================================================

    public async Task AddFamilyMemberAsync(EmployeeFamilyMember entity)
    {
        _context.EmployeeFamilyMembers.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> FamilyMemberExistsAsync(string appId, string idNo)
    {
        return await _context.EmployeeFamilyMembers
            .AnyAsync(x => x.AppId == appId && x.IdNo == idNo);
    }

    public async Task<EmployeeFamilyMember?> GetFamilyMemberAsync(string appId, string idNo)
    {
        return await _context.EmployeeFamilyMembers
            .FirstOrDefaultAsync(x => x.AppId == appId && x.IdNo == idNo);
    }

    // ======================================================
    // CHECK IF FAMILY DETAILS EXIST
    // ======================================================

    public async Task<bool> FamilyDetailsExistsAsync(string appId)
    {
        return await _context.EmployeeFamilyMembers
            .AnyAsync(x => x.AppId == appId && x.IsExists == "Y");
    }

    public async Task UpdateFamilyMemberAsync(EmployeeFamilyMember entity)
    {
        _context.EmployeeFamilyMembers.Update(entity);
        await _context.SaveChangesAsync();
    }

    // ======================================================
    // CCA MODULE
    // ======================================================

    public async Task AddCcaDetailsAsync(EmployeeCcaLocation entity)
    {
        _context.EmployeeCcaLocations.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> CcaDetailsExistsAsync(string appId)
    {
        return await _context.EmployeeCcaLocations
            .AnyAsync(x => x.AppId == appId && x.IsExists == "Y");
    }

    public async Task<EmployeeCcaLocation?> GetCcaDetailsByAppIdAsync(string appId)
    {
        return await _context.EmployeeCcaLocations
            .FirstOrDefaultAsync(x => x.AppId == appId);
    }

    public async Task UpdateCcaDetailsAsync(EmployeeCcaLocation entity)
    {
        _context.EmployeeCcaLocations.Update(entity);
        await _context.SaveChangesAsync();
    }

    // ======================================================
    // FAMILY PHOTO MODULE
    // ======================================================

    public async Task<WbhsFamilyPhotoSignature?> GetFamilyPhotoAsync(string appId, string idNo)
    {
        return await _context.WbhsFamilyPhotoSignatures
            .FirstOrDefaultAsync(x => x.AppId == appId && x.IdNo == idNo);
    }

    // ======================================================
    // METHOD : SaveFamilyPhotoAsync
    // PURPOSE: Insert or Update family photo & signature
    // TABLE  : wbhs_familydetails_inservice_online_photo_signature
    // ======================================================

    public async Task SaveFamilyPhotoAsync(WbhsFamilyPhotoSignature entity)
    {
        // Check if photo record already exists for this AppId + IdNo
        var existing = await _context.WbhsFamilyPhotoSignatures
            .FirstOrDefaultAsync(x => x.AppId == entity.AppId && x.IdNo == entity.IdNo);

        if (existing == null)
        {
            // --------------------------------------------------
            // INSERT NEW PHOTO RECORD
            // --------------------------------------------------
            await _context.WbhsFamilyPhotoSignatures.AddAsync(entity);
        }
        else
        {
            // --------------------------------------------------
            // UPDATE EXISTING PHOTO RECORD
            // --------------------------------------------------

            existing.EmpBenImgPhoto = entity.EmpBenImgPhoto;
            existing.EmpBenImgSig = entity.EmpBenImgSig;
            existing.EmpBenPhotoFileName = entity.EmpBenPhotoFileName;
            existing.EmpBenSigFileName = entity.EmpBenSigFileName;
            existing.PsEmpStatus = entity.PsEmpStatus;
            existing.PsEmpIsExists = entity.PsEmpIsExists;

            _context.WbhsFamilyPhotoSignatures.Update(existing);
        }

        // Save changes to database
        await _context.SaveChangesAsync();
    }

    // ======================================================
    // GET ALL FAMILY MEMBERS
    // ======================================================

    public async Task<List<EmployeeFamilyMember>> GetFamilyMembersByAppIdAsync(string appId)
    {
        return await _context.EmployeeFamilyMembers
            .Where(x => x.AppId == appId && x.IsExists == "Y")
            .ToListAsync();
    }
}