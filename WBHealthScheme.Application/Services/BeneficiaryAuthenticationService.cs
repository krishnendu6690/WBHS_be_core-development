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
        public async Task<List<BeneficiaryAuthenticationResponse>>
        GetBeneficiaryByUniqueIdAsync(string uniqueId)
        {
            if (string.IsNullOrWhiteSpace(mobileNumber))
                throw new BusinessRuleException("Unique ID is required");
            if (mobileNumber.Length != 11| !mobileNumber.All(char.IsDigit))
                throw new BusinessRuleException("Invalid Unique ID");
            var result = await
                _repository.GetBeneficiaryByUniqueIdAsync(uniqueId);
            if (result == null || !result.Any())
                throw new NotFoundException("Beneficiary not found");
            return result;
        }
    }
}