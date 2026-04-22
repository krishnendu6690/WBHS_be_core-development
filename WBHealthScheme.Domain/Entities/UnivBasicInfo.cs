namespace WBHealthScheme.Domain.Entities;

public class UnivBasicInfo
{
    public string SlrNo { get; set; }
    public string AppId { get; set; }
    public string PanId { get; set; }

    public string UnivFirstName { get; set; }
    public string UnivLastName { get; set; }
    public DateTime? UnivDob { get; set; }
    public string MtsStsCd { get; set; }
    public string Sex { get; set; }
    public string EmpDistCd { get; set; }
    public string EmpAddr { get; set; }
    public string PanVoterNo { get; set; }
    public string MobileNo { get; set; }
    public string EmailId { get; set; }

    public string ResidencePhNo { get; set; }
    public DateTime? Redate { get; set; }

    public string BnkNm { get; set; }
    public string BnkBrNm { get; set; }
    public string BnkIfsc { get; set; }
    public string BnkAcNo { get; set; } // renamed (hyphen issue)

    public string IsExists { get; set; }
    public string MemoNo { get; set; }
    public DateTime? MemoDate { get; set; }
    public DateTime? DdoVerifyDate { get; set; }
    public string RejectReason { get; set; }
    public DateTime? DdoRejectDate { get; set; }
    public string IdType { get; set; }
    public DateTime? EffectDate { get; set; }
    public string BnkMicr { get; set; }
    public string ApproverName { get; set; }
    public string ApproverDesig { get; set; }
    public string Reyear { get; set; }
    public string AdharNo { get; set; }
}