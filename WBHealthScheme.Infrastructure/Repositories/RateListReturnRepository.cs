using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using WBHealthScheme.Application.Dtos;
using WBHealthScheme.Application.Interfaces;
using WBHealthScheme.Infrastructure.Persistence;
namespace WBHealthScheme.Infrastructure.Repositories
{
    public class RateListReturnRepository: IRatelistReturnRepository
    {
        private readonly WBHSDbContext _context;

        public RateListReturnRepository(WBHSDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReturnRatelistResponse>>
        GetRatelistByNameAsync(string Description)
        {
            var param = new SqlParameter("@Rate_code", Description);
            var result = await _context.CodeDetails
                        .FromSqlRaw("EXEC GET_RATE_CODE_BY_NAME @Rate_code", param)
                        .AsNoTracking()
                        .ToListAsync();
            return result;
        }


    }
}