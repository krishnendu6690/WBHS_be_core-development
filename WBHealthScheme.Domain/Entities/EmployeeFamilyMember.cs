namespace WBHealthScheme.Domain.Entities;

public class EmployeeFamilyMember
{
    public long SerialNo { get; set; }
    public string AppId { get; set; } = null!;
    public string IdNo { get; set; } = null!;

    public string? Name { get; set; }
    public string? Age { get; set; }
    public string? MemberCode { get; set; }
    public string? MonthlyIncome { get; set; }
    public DateTime? Dob { get; set; }

    public string IsExists { get; set; } = "Y";
    public string? Status { get; set; }
    public DateTime? DateOfDeath { get; set; }

    public string? BenHrmsId { get; set; }
    public string? TermCause { get; set; }
    public DateTime? TermDatetime { get; set; }
    public DateTime? EffectDatetime { get; set; }
    public string? AadhaarNo { get; set; }
    public string? Category { get; set; }
    public DateTime? ValidUpTo { get; set; }
    public string? MobileNo { get; set; }
    public string? Email { get; set; }
    public DateTime? WefDatetime { get; set; }
    public string? FmlyPenAppId { get; set; }
    public string? FmlyPenPpoId { get; set; }
    public string? FtpPhotoLocn { get; set; }
    public string? FtpSignLocn { get; set; }
    public string? BloodGroup { get; set; }
}
