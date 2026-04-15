namespace WBHealthScheme.Application.DTOs;

public class UpdateCcaDetailsRequest
{
    public string ApplicationId { get; set; } = null!;

    public string? LocnFlg { get; set; }

    public string? DeptCd { get; set; }

    public string? DteCd { get; set; }

    public string? OffTypCd { get; set; }

    public string? AttachOffCd { get; set; }

    public string? RegOffCd { get; set; }

    public string? CadreCd { get; set; }

    public string? OrgDsgCd { get; set; }
}