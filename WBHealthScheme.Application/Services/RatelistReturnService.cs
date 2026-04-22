using WBHealthScheme.Application.Dtos;
using WBHealthScheme.Application.Exceptions;
using WBHealthScheme.Application.Interfaces;
namespace WBHealthScheme.Application.Services
{
    public class RatelistReturnService : IRatelistReturnService
    {
        private readonly IRatelistReturnRepository _repository;

        public RatelistReturnService(IRatelistReturnRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ReturnRatelistResponse>>

        GetRatelistByNameAsync(string Description)
        {
            if (string.IsNullOrWhiteSpace(Description))
            throw new BusinessRuleException("Description is required");
            //if (Description.Length != 7 || !Description.All(char.IsDigit))
            //throw new BusinessRuleException("Invalid Description");
            var result = await
            _repository.GetRatelistByNameAsync(Description);
            if (result == null || !result.Any())
            throw new NotFoundException("CODE not found");
            return result;
        }

        

    }
}