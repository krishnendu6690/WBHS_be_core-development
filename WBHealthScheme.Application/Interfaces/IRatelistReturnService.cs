using WBHealthScheme.Application.Dtos;

namespace WBHealthScheme.Application.Interfaces
{
    public interface IRatelistReturnService
    {
        Task<List<ReturnRatelistResponse>>
         GetRatelistByNameAsync(string Description);
    }
}