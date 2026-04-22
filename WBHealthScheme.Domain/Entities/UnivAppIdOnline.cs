namespace WBHealthScheme.Domain.Entities;
public class UnivAppIdOnline
{
    public string SlrNo { get; set; }          // SLR_NO (PK likely)
    public string PanId { get; set; }          // PAN_ID
    public string AppId { get; set; }          // APP_ID
    public DateTime Dob { get; set; }          // DOB
    public string? DistCd { get; set; }        // dist_cd
    public string IsExists { get; set; }       // IS_EXISTS
    public DateTime? InvalidTime { get; set; } // INVALID_TIME
    public string? CreateIp { get; set; }      // CREATE_IP
    public DateTime CreatTime { get; set; }       // CR_TIME
}