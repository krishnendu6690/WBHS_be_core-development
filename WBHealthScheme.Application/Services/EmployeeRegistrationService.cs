using WBHealthScheme.Application.DTOs;
using WBHealthScheme.Application.Exceptions;
using WBHealthScheme.Application.Interfaces.Repositories;
using WBHealthScheme.Application.Interfaces.Services;
using WBHealthScheme.Domain.Common;
using WBHealthScheme.Domain.Entities;

namespace WBHealthScheme.Application.Services;

public class EmployeeRegistrationService : IEmployeeRegistrationService
{
    private readonly IEmployeeRegistrationRepository _repository;

    public EmployeeRegistrationService(IEmployeeRegistrationRepository repository)
    {
        _repository = repository;
    }

    // ======================================================
    // STEP 1 - Create Application / Generate GPF
    // ======================================================
    public async Task<CreateApplicationResponse> CreateApplicationAsync(CreateApplicationRequest request)
    {
        string gpfNo;
        if (request.HasGpf)
        {
            if (string.IsNullOrWhiteSpace(request.GpfNo))
                throw new BusinessRuleException("GPF/PRAN number is required when HasGpf is true.");
            gpfNo = request.GpfNo!;
        }
        else
        {
            gpfNo = $"NONGPF/WB/{DateTime.Now:yyyyMMddHHmmssfff}";
        }

        var lastId = await _repository.GetLastApplicationIdAsync();
        long nextSequence = 1;
        if (!string.IsNullOrEmpty(lastId))
        {
            // Format: WB/EMP/000000001 — last 9 chars are the sequence
            var seqPart = lastId.Substring(lastId.LastIndexOf('/') + 1);
            if (long.TryParse(seqPart, out long parsed))
                nextSequence = parsed + 1;
        }

        var applicationId = $"WB/EMP/{nextSequence:D9}";

        var entity = new WbhsApplicationIdEmpOnline
        {
            AppId = applicationId,
            EmpId = gpfNo,
            EmpDistCd = request.LocationCode,
            IsExists = "Y",
            AppIdTime = DateTime.Now
        };

        await _repository.SaveApplicationAsync(entity);

        return new CreateApplicationResponse
        {
            Success = true,
            Message = "Application created successfully",
            Data = new { applicationId, gpfNo, dateOfJoining = request.DateOfJoining }
        };
    }

    // ======================================================
    // STEP 1b - District & DOB
    // ======================================================
    public async Task<ApiResponse<object>> InitiateRegistrationAsync(InitiateRegistrationRequest request)
    {
        var application = await _repository.GetApplicationAsync(request.ApplicationId)
            ?? throw new BusinessRuleException("Application not found.");

        var alreadyInitiated = await _repository.PersonalDetailsExistsAsync(request.ApplicationId);
        if (alreadyInitiated)
            throw new BusinessRuleException("Application already initiated.");

        var entity = new EmployeeBasicInfo
        {
            AppId = request.ApplicationId,
            EmpId = request.EmpId,
            EmpDistCd = request.DistrictCode,
            EmpDob = request.Dob.ToDateTime(TimeOnly.MinValue),
            EmpOfficeAddress = string.Empty,
            EmpCadreCode = string.Empty,
            NonExistsDesig = string.Empty,
            PanVoterNo = string.Empty,
            MobileNo = string.Empty,
            IsExists = "Y",
            EmpEnrollmentTime = DateTime.Now
        };

        await _repository.AddPersonalDetailsAsync(entity);

        return new ApiResponse<object>
        {
            Success = true,
            Message = "Registration initiated successfully.",
            Data = new { request.ApplicationId, request.DistrictCode, dob = request.Dob }
        };
    }

    // ======================================================
    // STEP 2 - Personal Details
    // ======================================================
    public async Task<ApiResponse<object>> AddPersonalDetailsAsync(CreatePersonalDetailsRequest request)
    {
        var application = await _repository.GetApplicationAsync(request.ApplicationId)
            ?? throw new BusinessRuleException("Application not found.");

        var entity = new EmployeeBasicInfo
        {
            AppId = request.ApplicationId,
            EmpId = request.EmpId,
            EmpFirstName = request.FirstName,
            EmpLastName = request.LastName,
            EmpDob = request.Dob.ToDateTime(TimeOnly.MinValue),
            EmpOfficeAddress = request.OfficeAddress,
            EmpCadreCode = request.CadreCode,
            NonExistsDesig = request.NonExistingDesignation,
            EmpDistCd = request.DistrictCode,
            EmpAdd = request.ResidentialAddress,
            PanVoterNo = request.PanOrVoterNo,
            MobileNo = request.MobileNo,
            EmailId = request.Email,
            ResidencePhone = request.ResidencePhone,
            AadhaarNo = request.AadhaarNo,
            DateOfJoining = request.DateOfJoining?.ToDateTime(TimeOnly.MinValue),
            HrmsId = request.HrmsId,
            PayLevel = request.PayLevel,
            BasicSalary = request.BasicSalary,
            BankName = request.BankName,
            BankBranchName = request.BankBranch,
            BankAccountNo = request.BankAccountNo,
            BankIfsc = request.BankIfsc,
            IsExists = "Y",
            EmpEnrollmentTime = DateTime.Now
        };

        await _repository.AddPersonalDetailsAsync(entity);

        return new ApiResponse<object>
        {
            Success = true,
            Message = "Personal details saved successfully.",
            Data = new { request.ApplicationId }
        };
    }

    // ======================================================
    // STEP 3 - Office Details
    // ======================================================
    public async Task<ApiResponse<object>> AddOfficeDetailsAsync(CreateOfficeDetailsRequest request)
    {
        var application = await _repository.GetApplicationAsync(request.ApplicationId)
            ?? throw new BusinessRuleException("Application not found.");

        var personalExists = await _repository.PersonalDetailsExistsAsync(request.ApplicationId);
        if (!personalExists)
            throw new BusinessRuleException("Complete Personal Details first.");

        var entity = new EmployeeOfficeLink
        {
            AppId = request.ApplicationId,
            EmpId = request.EmpId,
            DeptCd = request.DeptCd,
            OffTypCd = request.OffTypCd,
            DteCd = request.DteCd,
            IsExists = "Y"
        };

        await _repository.AddOfficeDetailsAsync(entity);

        return Success(request.ApplicationId);
    }

    // ======================================================
    // STEP 4 - Family Member
    // ======================================================
    public async Task<ApiResponse<object>> AddFamilyMemberAsync(CreateFamilyMemberRequest request)
    {
        var application = await _repository.GetApplicationAsync(request.ApplicationId)
            ?? throw new BusinessRuleException("Application not found.");

        var officeExists = await _repository.OfficeDetailsExistsAsync(request.ApplicationId);
        if (!officeExists)
            throw new BusinessRuleException("Complete Office Details first.");

        var exists = await _repository.FamilyMemberExistsAsync(request.ApplicationId, request.IdNo);
        if (exists)
            throw new BusinessRuleException("Family member already exists.");

        var entity = new EmployeeFamilyMember
        {
            AppId = request.ApplicationId,
            IdNo = request.IdNo,
            Name = request.Name,
            MemberCode = request.MemberCode,
            Dob = request.Dob.ToDateTime(TimeOnly.MinValue),
            Category = request.Category,
            MonthlyIncome = request.MonthlyIncome?.ToString(),
            BloodGroup = request.BloodGroup,
            AadhaarNo = request.AadhaarNo,
            MobileNo = request.MobileNo,
            Email = request.Email,
            IsExists = "Y"
        };

        await _repository.AddFamilyMemberAsync(entity);

        return new ApiResponse<object> { Success = true, Message = "Family member added successfully.", Data = new { request.ApplicationId } };
    }

    // ======================================================
    // STEP 5 - CCA Details
    // ======================================================
    public async Task<ApiResponse<object>> AddCcaDetailsAsync(CreateCcaDetailsRequest request)
    {
        var application = await _repository.GetApplicationAsync(request.ApplicationId)
            ?? throw new BusinessRuleException("Application not found.");

        var familyExists = await _repository.FamilyDetailsExistsAsync(request.ApplicationId);
        if (!familyExists)
            throw new BusinessRuleException("Add at least one family member first.");

        var entity = new EmployeeCcaLocation
        {
            AppId = request.ApplicationId,
            EmpId = request.EmpId,
            DeptCd = request.DeptCd,
            DteCd = request.DteCd,
            IsExists = "Y"
        };

        await _repository.AddCcaDetailsAsync(entity);

        return Success(request.ApplicationId);
    }

    // ======================================================
    // SUBMIT APPLICATION
    // ======================================================
    public async Task<ApiResponse<object>> SubmitApplicationAsync(string applicationId)
    {
        var application = await _repository.GetApplicationAsync(applicationId)
            ?? throw new BusinessRuleException("Application not found.");

        var ccaExists = await _repository.CcaDetailsExistsAsync(applicationId);
        if (!ccaExists)
            throw new BusinessRuleException("Complete all steps before submission.");

        var familyMembers = await _repository.GetFamilyMembersByAppIdAsync(applicationId);
        if (!familyMembers.Any())
            throw new BusinessRuleException("At least one family member is required before submission.");

        foreach (var member in familyMembers)
        {
            var photo = await _repository.GetFamilyPhotoAsync(applicationId, member.IdNo);
            if (photo == null || photo.EmpBenImgPhoto == null || photo.EmpBenImgSig == null)
                throw new BusinessRuleException($"Photo and signature must be uploaded for family member: {member.Name}");
        }

        // Mark as submitted using INVALID_TIME = null (active) — IS_EXISTS already Y
        // No status column — submission is confirmed by all steps being complete
        application.IsExists = "Y";
        await _repository.UpdateApplicationAsync(application);

        return new ApiResponse<object>
        {
            Success = true,
            Message = "Application submitted successfully.",
            Data = new { applicationId }
        };
    }

    // ======================================================
    // PATCH PERSONAL DETAILS
    // ======================================================
    public async Task<ApiResponse<object>> UpdatePersonalDetailsAsync(UpdatePersonalDetailsRequest request)
    {
        var entity = await _repository.GetPersonalDetailsByAppIdAsync(request.ApplicationId)
            ?? throw new BusinessRuleException("Personal details not found.");

        if (!string.IsNullOrEmpty(request.FirstName)) entity.EmpFirstName = request.FirstName;
        if (!string.IsNullOrEmpty(request.LastName)) entity.EmpLastName = request.LastName;
        if (!string.IsNullOrEmpty(request.MobileNo)) entity.MobileNo = request.MobileNo;
        if (!string.IsNullOrEmpty(request.OfficeAddress)) entity.EmpOfficeAddress = request.OfficeAddress;

        await _repository.UpdatePersonalDetailsAsync(entity);

        return new ApiResponse<object> { Success = true, Message = "Personal details updated successfully." };
    }

    // ======================================================
    // PATCH OFFICE DETAILS
    // ======================================================
    public async Task<ApiResponse<object>> UpdateOfficeDetailsAsync(UpdateOfficeDetailsRequest request)
    {
        var entity = await _repository.GetOfficeDetailsByAppIdAsync(request.ApplicationId)
            ?? throw new BusinessRuleException("Office details not found.");

        if (!string.IsNullOrEmpty(request.DeptCd)) entity.DeptCd = request.DeptCd;
        if (!string.IsNullOrEmpty(request.DteCd)) entity.DteCd = request.DteCd;

        await _repository.UpdateOfficeDetailsAsync(entity);

        return new ApiResponse<object> { Success = true, Message = "Office details updated successfully." };
    }

    // ======================================================
    // PATCH FAMILY MEMBER
    // ======================================================
    public async Task<ApiResponse<object>> UpdateFamilyMemberAsync(UpdateFamilyMemberRequest request)
    {
        var entity = await _repository.GetFamilyMemberAsync(request.ApplicationId, request.IdNo)
            ?? throw new BusinessRuleException("Family member not found.");

        if (!string.IsNullOrEmpty(request.Name)) entity.Name = request.Name;
        if (!string.IsNullOrEmpty(request.MemberCode)) entity.MemberCode = request.MemberCode;
        if (request.MonthlyIncome.HasValue) entity.MonthlyIncome = request.MonthlyIncome.Value.ToString();

        await _repository.UpdateFamilyMemberAsync(entity);

        return new ApiResponse<object> { Success = true, Message = "Family member updated successfully." };
    }

    // ======================================================
    // PATCH CCA DETAILS
    // ======================================================
    public async Task<ApiResponse<object>> UpdateCcaDetailsAsync(UpdateCcaDetailsRequest request)
    {
        var entity = await _repository.GetCcaDetailsByAppIdAsync(request.ApplicationId)
            ?? throw new BusinessRuleException("CCA details not found.");

        if (!string.IsNullOrEmpty(request.DeptCd)) entity.DeptCd = request.DeptCd;
        if (!string.IsNullOrEmpty(request.DteCd)) entity.DteCd = request.DteCd;
        if (!string.IsNullOrEmpty(request.OffTypCd)) entity.OffTypCd = request.OffTypCd;

        await _repository.UpdateCcaDetailsAsync(entity);

        return new ApiResponse<object> { Success = true, Message = "CCA details updated successfully." };
    }

    // ======================================================
    // UPLOAD FAMILY PHOTO
    // ======================================================
    public async Task UploadFamilyPhotoAsync(UploadFamilyPhotoCommand request)
    {
        var existing = await _repository.GetFamilyPhotoAsync(request.AppId, request.IdNo)
            ?? new WbhsFamilyPhotoSignature
            {
                AppId = request.AppId,
                IdNo = request.IdNo,
                PsEmpStatus = "A",
                PsEmpIsExists = "Y",
                PsEmpInsertedDatetime = DateTime.Now
            };

        existing.EmpBenImgPhoto = request.PhotoBytes;
        existing.EmpBenImgSig = request.SignatureBytes;
        existing.EmpBenPhotoFileName = request.PhotoFileName;
        existing.EmpBenSigFileName = request.SignatureFileName;

        await _repository.SaveFamilyPhotoAsync(existing);
    }

    // ======================================================
    // GET APPLICATION DETAILS
    // ======================================================
    public async Task<ApplicationDetailsResponse> GetApplicationDetailsAsync(string appId)
    {
        var application = await _repository.GetApplicationAsync(appId)
            ?? throw new BusinessRuleException("Application not found.");

        return new ApplicationDetailsResponse
        {
            Application = application,
            PersonalDetails = await _repository.GetPersonalDetailsByAppIdAsync(appId),
            OfficeDetails = await _repository.GetOfficeDetailsByAppIdAsync(appId),
            CcaDetails = await _repository.GetCcaDetailsByAppIdAsync(appId),
            FamilyMembers = await _repository.GetFamilyMembersByAppIdAsync(appId)
        };
    }

    private static ApiResponse<object> Success(string appId) =>
        new() { Success = true, Message = "Operation successful.", Data = new { appId } };
}
