namespace WBHealthScheme.Domain.Entities;

public class WbhsApplicationIdEmpOnline
{
    public string AppId { get; set; } = null!;
    public string EmpId { get; set; } = null!;
    public string EmpDistCd { get; set; } = null!;
    public string IsExists { get; set; } = "Y";
    public DateTime AppIdTime { get; set; } = DateTime.Now;
    public DateTime? InvalidTime { get; set; }
    public string? CreateIp { get; set; }

}