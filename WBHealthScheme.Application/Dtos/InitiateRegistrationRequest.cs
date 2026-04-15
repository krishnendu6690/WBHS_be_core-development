namespace WBHealthScheme.Application.DTOs;

public class InitiateRegistrationRequest
{
    public string ApplicationId { get; set; } = null!;
    public string EmpId { get; set; } = null!;
    public string DistrictCode { get; set; } = null!;
    public DateOnly Dob { get; set; }
}
