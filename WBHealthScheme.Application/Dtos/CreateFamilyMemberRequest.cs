// ==========================================================
// DTO: CreateFamilyMemberRequest
// Purpose: Add Family Member (Step 4)
// Layer: Application
// ==========================================================

namespace WBHealthScheme.Application.DTOs;

public class CreateFamilyMemberRequest
{
    public string ApplicationId { get; set; } = null!;

    public string IdNo { get; set; } = null!;

    // UI fields (not stored in DB but used for validation)
    public int SerialNo { get; set; }

    public int TotalMembers { get; set; }

    public string Name { get; set; } = null!;

    public string MemberCode { get; set; } = null!;

    // Enterprise practice: DOB should be DateOnly
    public DateOnly Dob { get; set; }

    public string? Category { get; set; }

    public decimal? MonthlyIncome { get; set; }

    public string? BloodGroup { get; set; }

    public string? AadhaarNo { get; set; }

    public string? MobileNo { get; set; }

    public string? Email { get; set; }
}