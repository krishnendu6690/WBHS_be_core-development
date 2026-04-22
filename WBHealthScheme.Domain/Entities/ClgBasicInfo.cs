namespace ClgBasicInfo.Entities;
   public class ClgBasicInfo
{     
    public string SLR_NO { get; set; }       
    public string APP_ID { get; set; }        
    public string HRMS_ID { get; set; }        
    public string CLG_FirstName { get; set; }        
    public string CLG_LastName { get; set; }        
    public DateTime? CLG_Dob { get; set; }       
    public string MTS_STS_CD { get; set; }      
    public string sex { get; set; }        
    public string EMP_DIST_CD { get; set; }        
    public string empAddr { get; set; }        
    public string PAN_VOTER_NO { get; set; } 
    public string MOBILE_NO { get; set; }       
    public string EMAIL_ID { get; set; }      
    public string RESIDENCE_PH_NO { get; set; }    
    public string Retirement_age { get; set; }       
    public DateTime? redate { get; set; }       
    public string bnk_ifsc { get; set; }        
    public string bnk_nm { get; set; }       
    public string bnk_br_nm { get; set; }        
    public string bnk_micr { get; set; }        

    // ⚠️ keep valid C# name
    public string bnk_ac_no { get; set; }         

    public string IS_EXISTS { get; set; }        
    public string Memo_No { get; set; }        
    public DateTime? Memo_Date { get; set; }        
    public DateTime? DDO_VERIFY_DATE { get; set; }        
    public string Reject_Reason { get; set; }       
    public DateTime? DDO_reject_date { get; set; }        
    public string id_type { get; set; }        
    public DateTime? effect_date { get; set; }
    public string Aadhaar_Card_No { get; set; }        
    public DateTime? DATE_OF_DEATH { get; set; }
}