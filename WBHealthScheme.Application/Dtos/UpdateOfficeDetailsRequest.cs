// ==========================================================
// DTO: UpdateOfficeDetailsRequest
// Purpose: Used for PATCH update of Office Details
// ==========================================================

namespace WBHealthScheme.Application.DTOs;

public class UpdateOfficeDetailsRequest
{
    /// <summary>
    /// Application Id used to locate record
    /// </summary>
    public string ApplicationId { get; set; }

    /// <summary>
    /// Location Flag
    /// </summary>
    public string? LocnFlg { get; set; }

    /// <summary>
    /// Department Code
    /// </summary>
    public string? DeptCd { get; set; }

    /// <summary>
    /// Directorate Code
    /// </summary>
    public string? DteCd { get; set; }

    /// <summary>
    /// Office Type Code
    /// </summary>
    public string? OffTypCd { get; set; }

    /// <summary>
    /// Directorate name if not present in master
    /// </summary>
    public string? NonExistsDte { get; set; }
}