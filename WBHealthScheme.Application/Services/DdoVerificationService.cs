using WBHealthScheme.Application.DTOs.Ddo;
using WBHealthScheme.Application.Interfaces.Repositories;
using WBHealthScheme.Application.Interfaces.Services;

namespace WBHealthScheme.Application.Services;

public class DdoVerificationService : IDdoVerificationService
{
    private readonly IRegistrationVerificationRepository _repository;

    public DdoVerificationService(IRegistrationVerificationRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<DdoApplicationListDto>> GetSubmittedApplicationsAsync()
    {
        var applications = await _repository.GetSubmittedApplicationsAsync();

        return applications.Select(x => new DdoApplicationListDto
        {
            ApplicationId = x.AppId,
            EmpId = x.EmpId,
            DistrictCode = x.EmpDistCd,
            Status = "Submitted",
            CreatedTime = x.AppIdTime
        }).ToList();
    }

    public async Task VerifyApplicationAsync(DdoVerifyRequest request)
    {
        var personal = await _repository.GetPersonalAsync(request.ApplicationId)
            ?? throw new Exception("Application not found.");

        if (personal.DdoVerifyDate != null)
            throw new Exception("Application already verified by DDO.");

        personal.DdoVerifyDate = DateTime.Now;

        await _repository.UpdatePersonalAsync(personal);
    }

    public async Task RejectApplicationAsync(DdoRejectRequest request)
    {
        var personal = await _repository.GetPersonalAsync(request.ApplicationId)
            ?? throw new Exception("Application not found.");

        // Mark as DDO rejected by setting DdoVerifyDate to a sentinel past date
        personal.DdoVerifyDate = DateTime.MinValue;

        await _repository.UpdatePersonalAsync(personal);
    }
}
