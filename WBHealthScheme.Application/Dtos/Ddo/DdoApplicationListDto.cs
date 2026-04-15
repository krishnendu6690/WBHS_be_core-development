// ==========================================================
// DTO: DdoApplicationListDto
// Purpose: Represents application data for DDO dashboard
// Layer: Application
// ==========================================================

namespace WBHealthScheme.Application.DTOs.Ddo;

public class DdoApplicationListDto
{
    public string ApplicationId { get; set; } = string.Empty;

    public string EmpId { get; set; } = string.Empty;

    public string DistrictCode { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public DateTime CreatedTime { get; set; }
}