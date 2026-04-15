using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WBHealthScheme.Domain.Entities;

[Table("wbhs_familyDetails_inservice_ONLINE_PHOTO_SIGNATURE", Schema = "dbo")]
public class WbhsFamilyPhotoSignature
{
    [Key]
    [Column("PS_EMP_ID")]
    public int PsEmpId { get; set; }

    [Column("APP_ID")]
    public string AppId { get; set; } = null!;

    [Column("idno")]
    public string IdNo { get; set; } = null!;

    [Column("EMP_HRMS_ID")]
    public string? EmpHrmsId { get; set; }

    [Column("EMP_BEN_PHOTO_FILE_NAME")]
    public string? EmpBenPhotoFileName { get; set; }

    [Column("EMP_BEN_SIG_FILE_NAME")]
    public string? EmpBenSigFileName { get; set; }

    [Column("PS_EMP_STATUS")]
    public string PsEmpStatus { get; set; } = null!;

    [Column("PS_EMP_IS_EXISTS")]
    public string PsEmpIsExists { get; set; } = null!;

    [Column("PS_EMP_INVALID_DATETIME")]
    public DateTime? PsEmpInvalidDatetime { get; set; }

    [Column("PS_EMP_INSERTED_DATETIME")]
    public DateTime? PsEmpInsertedDatetime { get; set; }

    [Column("PS_EMP_STATUS_UPDATION_DATETIME")]
    public DateTime? PsEmpStatusUpdationDatetime { get; set; }

    [Column("PS_EMP_UPLOADING_ID")]
    public string? PsEmpUploadingId { get; set; }

    [Column("PS_EMP_UPLOADING_IP")]
    public string? PsEmpUploadingIp { get; set; }

    [Column("BEN_BLOOD_GROUP")]
    public string? BenBloodGroup { get; set; }

    [Column("PHOTO_FTP")]
    public string? PhotoFtp { get; set; }

    [Column("SIGN_FTP")]
    public string? SignFtp { get; set; }

    [Column("DELETE_FTP_FLAG")]
    public string? DeleteFtpFlag { get; set; }

    [Column("INSERT_FTP_FLAG")]
    public string? InsertFtpFlag { get; set; }

    [Column("EMP_BEN_IMG_PHOTO")]
    public byte[]? EmpBenImgPhoto { get; set; }

    [Column("EMP_BEN_IMG_SIG")]
    public byte[]? EmpBenImgSig { get; set; }
}
