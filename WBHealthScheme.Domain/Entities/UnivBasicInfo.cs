namespace WBHealthScheme.Domain.Entities;

public class MBUCTUnivBasicInfoOnline
{
    public string SLR_NO { get; set; }
    public string APP_ID { get; set; }
    public string PAN_ID { get; set; }

    public string UNIV_FirstName { get; set; }
    public string UNIV_LastName { get; set; }
    public DateTime? UNIV_Dob { get; set; }

    public string MTS_STS_CD { get; set; }
    public string sex { get; set; }
    public string EMP_DIST_CD { get; set; }

    public string empAddr { get; set; }
    public string PAN_VOTER_NO { get; set; }
    public string MOBILE_NO { get; set; }
    public string EMAIL_ID { get; set; }

    public string RESIDENCE_PH_NO { get; set; }
    public DateTime? redate { get; set; }

    public string bnk_nm { get; set; }
    public string bnk_br_nm { get; set; }
    public string bnk_ifsc { get; set; }
    public string bnk_ac-no { get; set; } // renamed (hyphen issue)

    public string IS_EXISTS { get; set; }
    public string Memo_No { get; set; }
    public DateTime? Memo_Date { get; set; }

    public DateTime? DDO_VERIFY_DATE { get; set; }
    public string Reject_Reason { get; set; }
    public DateTime? DDO_reject_date { get; set; }

    public string id_type { get; set; }
    public DateTime? effect_date { get; set; }

    public string bnk_micr { get; set; }
    public string APPROVER_NAME { get; set; }
    public string APPROVER_DESIG { get; set; }

    public string reyear { get; set; }
    public string Adhar_No { get; set; }
}