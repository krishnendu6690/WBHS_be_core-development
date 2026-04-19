using WBHealthScheme.Application.Dtos;
namespace WBHealthScheme.Application.Interfaces
{
    public interface IBeneficiaryAuthenticationService
    {
        Task<List<BeneficiaryAuthenticationResponse>>
        GetBeneficiaryByMobileAsync(string mobileNumber);

        Task<List<Beneiciary_ward_resp_broto>>
        GetwardByappAsync(string app_ID);

        Task<List<UnivBeneficiaryAuthenticationResponse>>
        GetBeneficiaryByUniqueIdAsync(string uniqueId);

        Task<List<ClgBeneficiaryAuthenticationResponse>>
        GetBeneficiaryByHrmsIdClgAsync(string hrmsId);

        Task<List<PnhytEmpBeneficiaryAuthenticationResponse>>
        GetBeneficiaryByIosmsIdAsync(string iosmsId);
    }
}