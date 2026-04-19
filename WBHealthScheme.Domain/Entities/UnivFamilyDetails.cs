namespace WBHealthScheme.Domain.Entities;

public class UnivfamilyDetails
    {
        public string SlrNo { get; set; }
        public string AppId { get; set; }
        public string PanId { get; set; } 
        public string BenId { get; set; } 
        public string? BenNm { get; set; }
        public DateTime? BenDob { get; set; }
        public string? Age { get; set; }
        public string? Income { get; set; }
        public string? Relation { get; set; }
        public string? BldGrp { get; set; }
        public string? IdType { get; set; }
        public string? IdNo { get; set; }
        public string? BenPhotoFileName { get; set; }
        public byte[]? BenImgPhoto { get; set; }
        public string? BenSigFileName { get; set; }
        public byte[]? BenImgSig { get; set; }
        public string? PhotoFtp { get; set; }
        public string? SignFtp { get; set; }
        public DateTime? StatusUpdationDatetime { get; set; }
        public string? UploadingId { get; set; }
        public string? UploadingIp { get; set; }
        public string? IsExists { get; set; }
        public string? Status { get; set; }
        public DateTime? DateDeath { get; set; }
        public string? TermCause { get; set; }
        public DateTime? TermDatetime { get; set; }
        public DateTime? InvalidDatetime { get; set; }
        public DateTime? InsertedDatetime { get; set; }
        public string? BenCat { get; set; }
        public DateTime? ValidUpto { get; set; }
        public string? BenMobNo { get; set; }
        public string? BenEmail { get; set; }
        public string? AdharNo { get; set; }
        public string? InsertFtpFlag { get; set; }
        public DateTime? ApproveRejectDatetime { get; set; }
        public DateTime? EffectDate { get; set; }
        public string? ApproveUser { get; set; }
        public string? ApproverUserRoll { get; set; }
        public string? ApproverName { get; set; }
        public string? ApproverDesig { get; set; }
    }