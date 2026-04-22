using WBHealthScheme.Application.Dtos;
namespace WBHealthScheme.Application.Interfaces
{
    public interface IRatelistReturnRepository
    {
        Task<List<ReturnRatelistResponse>>
        GetRatelistByNameAsync(string Description);
    }
}