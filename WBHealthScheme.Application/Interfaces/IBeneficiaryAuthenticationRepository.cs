using WBHealthScheme.Application.dtos;
using WBHealthScheme.Application.Dtos;
namespace WBHealthScheme.Application.Interfaces
{
    public interface IBeneficiaryAuthenticationRepository
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

        Task<List<PnhytPenBeneficiaryAuthenticationResponse>>
        GetBeneficiaryPnhytPenByAppIdAsync(string appId);

        Task<List<EmpPenBeneficiaryAuthenticationResponse>>
        GetBeneficiaryEmpPenByAppIdAsync(string appliId);

        Task<List<AllBeneficiaryAuthenticationResponseByMobileNo>>
        GetAllBeneficiaryByMobileAsync(string mobNumber);
    }
}