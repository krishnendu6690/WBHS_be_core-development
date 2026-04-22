using WBHealthScheme.Application.Dtos;
using WBHealthScheme.Application.Exceptions;
using WBHealthScheme.Application.Interfaces;
namespace WBHealthScheme.Application.Services
{
    public class BeneficiaryAuthenticationService :
    IBeneficiaryAuthenticationService
    {
        private readonly IBeneficiaryAuthenticationRepository _repository;
        public
        BeneficiaryAuthenticationService(IBeneficiaryAuthenticationRepository
        repository)
        {
            _repository = repository;
        }
        public async Task<List<BeneficiaryAuthenticationResponse>>
        GetBeneficiaryByMobileAsync(string mobileNumber)
        {
            if (string.IsNullOrWhiteSpace(mobileNumber))
                throw new BusinessRuleException("Mobile number is required");
            if (mobileNumber.Length != 10 || !mobileNumber.All(char.IsDigit))
                throw new BusinessRuleException("Invalid mobile number");
            var result = await
                _repository.GetBeneficiaryByMobileAsync(mobileNumber);
            if (result == null || !result.Any())
                throw new NotFoundException("Beneficiary not found");
            return result;
        }
        
        public async Task<List<UnivBeneficiaryAuthenticationResponse>>
        GetBeneficiaryByUniqueIdAsync(string uniqueId)
        {
            if (string.IsNullOrWhiteSpace(uniqueId))
                throw new BusinessRuleException("Unique ID is required");
            if (uniqueId.Length != 11 
                || !uniqueId.Substring(0, 6).All(char.IsLetter) 
                || !uniqueId.Substring(6, 4).All(char.IsDigit) 
                ||!char.IsLetter(uniqueId[10]))
                throw new BusinessRuleException("Invalid Unique ID");
            var result = await
                _repository.GetBeneficiaryByUniqueIdAsync(uniqueId);
            if (result == null || !result.Any())
                throw new NotFoundException("Beneficiary not found");
            return result;
        }

         public async Task<List<Beneiciary_ward_resp_broto>>
        GetwardByappAsync(string app_ID)
        {
            if (string.IsNullOrWhiteSpace(app_ID))
                throw new BusinessRuleException("Enrollment ID is required");
            if (app_ID.Length != 10 || !app_ID.All(char.IsDigit))
                throw new BusinessRuleException("Invalid Enrollment ID");
            var result = await
                _repository.GetwardByappAsync(app_ID);
            if (result == null || !result.Any())
                throw new NotFoundException("Enrollment ID not found");
            return result;
        }

        public async Task<List<ClgBeneficiaryAuthenticationResponse>>
        GetBeneficiaryByHrmsIdClgAsync(string hrmsId)
        {
            if (string.IsNullOrWhiteSpace(hrmsId))
                throw new BusinessRuleException("HRMS ID is required");
            if (hrmsId.Length != 11 
                || !hrmsId.Substring(0, 1).All(char.IsLetter) 
                || !hrmsId.Substring(1, 10).All(char.IsDigit))
                throw new BusinessRuleException("Invalid HRMS ID");
            var result = await
                _repository.GetBeneficiaryByHrmsIdClgAsync(hrmsId);
            if (result == null || !result.Any())
                throw new NotFoundException("Beneficiary not found");
            return result;
        }

        public async Task<List<PnhytEmpBeneficiaryAuthenticationResponse>>
        GetBeneficiaryByIosmsIdAsync(string iosmsId)
        {
            if (string.IsNullOrWhiteSpace(iosmsId))
                throw new BusinessRuleException("IOSMS ID is required");
            if (iosmsId.Length != 12 
                || !iosmsId.Substring(0, 2).All(char.IsLetter) 
                || !iosmsId.Substring(2).All(char.IsDigit))
                throw new BusinessRuleException("Invalid IOSMS ID");
            var result = await
                _repository.GetBeneficiaryByIosmsIdAsync(iosmsId);
            if (result == null || !result.Any())
                throw new NotFoundException("Beneficiary not found");
            return result;
        }

        public async Task<List<PnhytPenBeneficiaryAuthenticationResponse>>
        GetBeneficiaryPnhytPenByAppIdAsync(string appId)
        {
            if (string.IsNullOrWhiteSpace(appId))
                throw new BusinessRuleException("App ID is required");
            appId = Uri.UnescapeDataString(appId);
            if (appId.Length != 17
                || appId[3] != '/'
                || appId[7] != '/'
                || !appId.Substring(0, 3).All(char.IsLetter)
                || !appId.Substring(4, 3).All(char.IsLetter)
                || !appId.Substring(8, 9).All(char.IsDigit))
                throw new BusinessRuleException("Invalid App ID");
            var result = await
                _repository.GetBeneficiaryPnhytPenByAppIdAsync(appId);
            if (result == null || !result.Any())
                throw new NotFoundException("Beneficiary not found");
            return result;
        }          
        
    }
}