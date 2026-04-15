using WBHealthScheme.Application.Dtos;
namespace WBHealthScheme.Application.Interfaces
{
    public interface IBeneficiaryAuthenticationService
    {
        Task<List<BeneficiaryAuthenticationResponse>>
        GetBeneficiaryByMobileAsync(string mobileNumber);

        Task<List<BeneficiaryAuthenticationResponse>>
        GetBeneficiaryByUniqueIdAsync(string uniqueId);
    }
}