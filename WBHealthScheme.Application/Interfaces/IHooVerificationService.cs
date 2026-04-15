using WBHealthScheme.Application.DTOs.Hoo;

namespace WBHealthScheme.Application.Interfaces.Services;

public interface IHooVerificationService
{
    Task<List<string>> GetDdoVerifiedApplicationsAsync();

    Task ApproveApplicationAsync(HooApproveRequest request);

    Task RejectApplicationAsync(HooApproveRequest request);
}