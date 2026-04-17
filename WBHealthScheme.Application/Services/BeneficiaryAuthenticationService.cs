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
            if (uniqueId.Length != 11)
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
        
        
    }
}