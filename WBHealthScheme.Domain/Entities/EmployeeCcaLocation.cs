// ==========================================================
// 
// Maps: wbhs_locnwise_cca_inservice_online
// 
// ==========================================================

namespace WBHealthScheme.Domain.Entities;

public class EmployeeCcaLocation
{
    public string AppId { get; set; } = null!;
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

    public string? NonExistsOrgDsg { get; set; }
    public string? CadreCd { get; set; }
    public string? OrgDsgCd { get; set; }

    public string IsExists { get; set; } = "Y";
}