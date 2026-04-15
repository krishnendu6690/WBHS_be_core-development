namespace WBHealthScheme.Domain.Entities;

public class EmployeeBasicInfo
{
    public string AppId { get; set; } = null!;
    public string EmpId { get; set; } = null!;

    public string? EmpFirstName { get; set; }
    public string? EmpLastName { get; set; }
    public DateTime EmpDob { get; set; }

    public string EmpOfficeAddress { get; set; } = null!;
    public string EmpCadreCode { get; set; } = null!;
    public string NonExistsDesig { get; set; } = null!;
    public string? Desig { get; set; }

    public string? PayBand { get; set; }
    public string? BandPay { get; set; }
    public string? GradePay { get; set; }
    public string? MtsStatusCode { get; set; }

    public string? Sex { get; set; }
    public string EmpDistCd { get; set; } = null!;
    public string? EmpAdd { get; set; }
    public string? EmpPostingDistCd { get; set; }

    public string PanVoterNo { get; set; } = null!;
    public string MobileNo { get; set; } = null!;
    public string? EmailId { get; set; }
    public string? ResidencePhone { get; set; }

    public DateTime? DateOfJoining { get; set; }
    public DateTime? Redate { get; set; }
    public DateTime? DateFormA { get; set; }
    public DateTime? DateFormB { get; set; }
    public DateTime? DateFormF { get; set; }

    public string? WardName { get; set; }
    public string? DdoCd { get; set; }
    public string IsExists { get; set; } = "Y";
    public DateTime EmpEnrollmentTime { get; set; }
    public DateTime? DdoVerifyDate { get; set; }

    public string? HrmsId { get; set; }
    public string? WithoutHrmsDeput { get; set; }
    public string? AadhaarNo { get; set; }

    public int? PayLevel { get; set; }
    public int? BasicSalary { get; set; }

    public string? WardTmc { get; set; }
    public string? WardGovt { get; set; }
    public string? MemoNo { get; set; }
    public DateTime? MemoDate { get; set; }

    public string? ApproveUser { get; set; }
    public string? ApproverUserRoll { get; set; }
    public string? ApproverName { get; set; }
    public string? ApproverDesig { get; set; }
    public string? ApproverHoo { get; set; }

    public string? BankName { get; set; }
    public string? BankBranchName { get; set; }
    public string? BankMicr { get; set; }
    public string? BankAccountNo { get; set; }
    public string? BankIfsc { get; set; }

    public string? TempSuspendYsNo { get; set; }
    public string? NonExistsBasicSalary { get; set; }
    public string? SuspOrderNo { get; set; }
    public DateTime? SuspOrderDate { get; set; }
    public DateTime? DateOfDeath { get; set; }
    public string? OptOutAppId { get; set; }
}


