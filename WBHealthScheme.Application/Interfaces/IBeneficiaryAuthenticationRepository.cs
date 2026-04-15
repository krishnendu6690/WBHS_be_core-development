using WBHealthScheme.Application.Dtos;
namespace WBHealthScheme.Application.Interfaces
{
    public interface IBeneficiaryAuthenticationRepository
    {
        Task<List<BeneficiaryAuthenticationResponse>>
        GetBeneficiaryByMobileAsync(string mobileNumber);

        Task<List<BeneficiaryAuthenticationResponse>>
        GetBeneficiaryByUniqueIdAsync(string uniqueId);
    }
}