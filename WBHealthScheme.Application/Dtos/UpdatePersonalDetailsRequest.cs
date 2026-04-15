// ==========================================================
// DTO: UpdatePersonalDetailsRequest
// Purpose: Partial update request for employee personal info
// Layer: Application
// Note:
// All fields are nullable so client can send only
// the fields that need to be updated.
// ==========================================================

namespace WBHealthScheme.Application.DTOs;

public class UpdatePersonalDetailsRequest
{
    public string ApplicationId { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MobileNo { get; set; }
    public string? OfficeAddress { get; set; }
    public string? PanOrVoterNo { get; set; }

    public DateTime? Dob { get; set; }

    public decimal? BasicSalary { get; set; }

    public string? BankName { get; set; }
    public string? BankAccountNo { get; set; }
    public string? BankIfsc { get; set; }
}