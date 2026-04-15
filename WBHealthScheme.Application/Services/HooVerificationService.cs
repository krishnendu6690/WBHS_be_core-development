using WBHealthScheme.Application.DTOs.Hoo;
using WBHealthScheme.Application.Interfaces.Repositories;
using WBHealthScheme.Application.Interfaces.Services;

namespace WBHealthScheme.Application.Services;

public class HooVerificationService : IHooVerificationService
{
    private readonly IRegistrationVerificationRepository _repository;

    public HooVerificationService(IRegistrationVerificationRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<string>> GetDdoVerifiedApplicationsAsync()
    {
        var apps = await _repository.GetDdoApprovedApplicationsAsync();
        return apps.Select(x => x.AppId).ToList();
    }

    public async Task ApproveApplicationAsync(HooApproveRequest request)
    {
        var personal = await _repository.GetPersonalAsync(request.ApplicationId)
            ?? throw new Exception("Application not found.");

        if (personal.DdoVerifyDate == null || personal.DdoVerifyDate == DateTime.MinValue)
            throw new Exception("Application not yet verified by DDO.");

        // Store HOO approval in APPROVE_USER column
        personal.ApproveUser = request.ApplicationId;

        await _repository.UpdatePersonalAsync(personal);
    }

    public async Task RejectApplicationAsync(HooApproveRequest request)
    {
        var personal = await _repository.GetPersonalAsync(request.ApplicationId)
            ?? throw new Exception("Application not found.");

        // Mark HOO rejected — clear approve user
        personal.ApproveUser = "REJECTED";

        await _repository.UpdatePersonalAsync(personal);
    }
}
