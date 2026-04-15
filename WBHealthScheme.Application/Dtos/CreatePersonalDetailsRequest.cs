// ==========================================================
// DTO: CreatePersonalDetailsRequest
// Purpose: Step 2 - Save Employee Personal Details
// Layer: Application
// ==========================================================

namespace WBHealthScheme.Application.DTOs;

public class CreatePersonalDetailsRequest
{
    public string ApplicationId { get; set; } = null!;
    public string EmpId { get; set; } = null!;

    // ======================================================
    // BASIC INFORMATION
    // ======================================================

    public string FirstName { get; set; } = null!;
    public string? LastName { get; set; }

    // DateOnly for API (Enterprise Best Practice)
    public DateOnly Dob { get; set; }

    public string? Gender { get; set; }

    // ======================================================
    // CONTACT DETAILS
    // ======================================================

    public string? ResidentialAddress { get; set; }

    public string MobileNo { get; set; } = null!;

    public string? Email { get; set; }

    public string? ResidencePhone { get; set; }

    // ======================================================
    // IDENTITY DETAILS
    // ======================================================

    // PAN or Voter ID
    public string PanOrVoterNo { get; set; } = null!;

    public string? AadhaarNo { get; set; }

    // ======================================================
    // OFFICE DETAILS
    // ======================================================

    public string OfficeAddress { get; set; } = null!;

    public string DistrictCode { get; set; } = null!;

    public string? PostingDistrictCode { get; set; }

    public string CadreCode { get; set; } = null!;

    public string? DesignationCode { get; set; }

    public string NonExistingDesignation { get; set; } = null!;

    public DateOnly? DateOfJoining { get; set; }

    // ======================================================
    // SALARY DETAILS
    // ======================================================

    public int? PayLevel { get; set; }

    public int? BasicSalary { get; set; }

    public string? PayBand { get; set; }

    public string? BandPay { get; set; }

    public string? GradePay { get; set; }

    // ======================================================
    // BANK DETAILS
    // ======================================================

    public string? BankName { get; set; }

    public string? BankBranch { get; set; }

    public string? BankMicr { get; set; }

    public string? BankAccountNo { get; set; }

    public string? BankIfsc { get; set; }

    // ======================================================
    // SYSTEM / ADMIN DETAILS
    // ======================================================

    public string? DdoCode { get; set; }

    public string? HrmsId { get; set; }

    public string? IsTemporarilySuspended { get; set; }

    public string? WithoutHrmsDeputation { get; set; }
}