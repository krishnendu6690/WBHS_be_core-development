// ==========================================================
// DTO: CreateOfficeDetailsRequest
// Layer: Application
// ==========================================================

namespace WBHealthScheme.Application.DTOs;

public class CreateOfficeDetailsRequest
{
    public string ApplicationId { get; set; } = null!;
    public string EmpId { get; set; } = null!;

    public string? LocnFlg { get; set; }
    public string? DeptCd { get; set; }
    public string? NonExistsDte { get; set; }
    public string? DteCd { get; set; }
    public string? OffTypCd { get; set; }
    public string? NonExistsAtch { get; set; }
    public string? AttachOffCd { get; set; }
    public string? DstSdivBlk { get; set; }
    public string? NonExistsRegOfc { get; set; }
    public string? RegOffCd { get; set; }
    public string? OtherOfcCd { get; set; }
    public string? NonExistsOtherOfc { get; set; }
}