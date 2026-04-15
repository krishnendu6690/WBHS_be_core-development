// ==========================================================
// DTO: UpdateFamilyMemberRequest
// Purpose: PATCH update of Family Member
// ==========================================================

namespace WBHealthScheme.Application.DTOs;

public class UpdateFamilyMemberRequest
{
    public string ApplicationId { get; set; }

    public string IdNo { get; set; }

    public string? Name { get; set; }

    public string? MemberCode { get; set; }

    public decimal? MonthlyIncome { get; set; }
}