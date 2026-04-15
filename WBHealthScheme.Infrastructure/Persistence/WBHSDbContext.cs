using Microsoft.EntityFrameworkCore;
using WBHealthScheme.Domain.Entities;

namespace WBHealthScheme.Infrastructure.Persistence;

public class WBHSDbContext : DbContext
{
    public WBHSDbContext(DbContextOptions<WBHSDbContext> options) : base(options) { }

    public DbSet<WbhsApplicationIdEmpOnline> EmployeeApplications => Set<WbhsApplicationIdEmpOnline>();
    public DbSet<EmployeeBasicInfo> EmployeeBasicInfos => Set<EmployeeBasicInfo>();
    public DbSet<EmployeeOfficeLink> EmployeeOfficeLinks => Set<EmployeeOfficeLink>();
    public DbSet<EmployeeFamilyMember> EmployeeFamilyMembers => Set<EmployeeFamilyMember>();
    public DbSet<EmployeeCcaLocation> EmployeeCcaLocations => Set<EmployeeCcaLocation>();
    public DbSet<WbhsDdoEmpList> WbhsDdoEmpList => Set<WbhsDdoEmpList>();
    public DbSet<EmployeeMaster> EmployeeMasters => Set<EmployeeMaster>();
    public DbSet<WbhsFamilyPhotoSignature> WbhsFamilyPhotoSignatures { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<WbhsApplicationIdEmpOnline>(entity =>
        {
            entity.ToTable("wbhs_APPLICATION_ID_EMP_ONLINE", "dbo");
            entity.HasKey(e => e.AppId);
            entity.Property(e => e.AppId).HasColumnName("APP_ID").HasMaxLength(200).IsRequired();
            entity.Property(e => e.EmpId).HasColumnName("empId").HasMaxLength(50).IsRequired();
            entity.Property(e => e.EmpDistCd).HasColumnName("EMP_DIST_CD").HasMaxLength(2).IsRequired();
            entity.Property(e => e.IsExists).HasColumnName("IS_EXISTS").HasMaxLength(1).IsRequired();
            entity.Property(e => e.AppIdTime).HasColumnName("APP_ID_TIME").HasDefaultValueSql("getdate()");
            entity.Property(e => e.InvalidTime).HasColumnName("INVALID_TIME");
            entity.Property(e => e.CreateIp).HasColumnName("CREATE_IP");
        });

        modelBuilder.Entity<EmployeeBasicInfo>(entity =>
        {
            entity.ToTable("wbhs_empBasicInfo_ONLINE", "dbo");
            entity.HasKey(e => new { e.EmpId, e.AppId });

            entity.Property(e => e.AppId).HasColumnName("app_id").HasMaxLength(200);
            entity.Property(e => e.EmpId).HasColumnName("empId").HasMaxLength(50);
            entity.Property(e => e.EmpFirstName).HasColumnName("empFirstName").HasMaxLength(100);
            entity.Property(e => e.EmpLastName).HasColumnName("empLastName").HasMaxLength(100);
            entity.Property(e => e.EmpDob).HasColumnName("empDob");
            entity.Property(e => e.EmpOfficeAddress).HasColumnName("EMP_OFC_ADD").IsRequired();
            entity.Property(e => e.EmpCadreCode).HasColumnName("emp_cadr_code").HasMaxLength(2).IsRequired();
            entity.Property(e => e.NonExistsDesig).HasColumnName("NON_EXISTS_DESIG").IsRequired();
            entity.Property(e => e.Desig).HasColumnName("desig").HasMaxLength(3);
            entity.Property(e => e.PayBand).HasColumnName("pay_band").HasMaxLength(2);
            entity.Property(e => e.BandPay).HasColumnName("band_pay").HasMaxLength(15);
            entity.Property(e => e.GradePay).HasColumnName("gd_pay");
            entity.Property(e => e.MtsStatusCode).HasColumnName("MTS_STS_CD").HasMaxLength(2);
            entity.Property(e => e.Sex).HasColumnName("sex").HasMaxLength(2);
            entity.Property(e => e.EmpDistCd).HasColumnName("EMP_DIST_CD").HasMaxLength(2).IsRequired();
            entity.Property(e => e.EmpAdd).HasColumnName("empAdd");
            entity.Property(e => e.PanVoterNo).HasColumnName("PAN_VOTER_NO").IsRequired();
            entity.Property(e => e.MobileNo).HasColumnName("MOBILE_NO").HasMaxLength(10).IsRequired();
            entity.Property(e => e.EmailId).HasColumnName("EMAIL_ID");
            entity.Property(e => e.ResidencePhone).HasColumnName("RESIDENCE_PH_NO");
            entity.Property(e => e.DateOfJoining).HasColumnName("DOJ");
            entity.Property(e => e.Redate).HasColumnName("redate");
            entity.Property(e => e.DateFormA).HasColumnName("date_Form_A");
            entity.Property(e => e.DateFormB).HasColumnName("date_Form_B");
            entity.Property(e => e.DateFormF).HasColumnName("Date_form_F");
            entity.Property(e => e.WardName).HasColumnName("ward_name").HasMaxLength(20);
            entity.Property(e => e.DdoCd).HasColumnName("DDO_CD").HasMaxLength(50);
            entity.Property(e => e.IsExists).HasColumnName("IS_EXISTS").HasMaxLength(1).IsRequired();
            entity.Property(e => e.EmpPostingDistCd).HasColumnName("EMP_POSTING_DIST_CD").HasMaxLength(2);
            entity.Property(e => e.EmpEnrollmentTime).HasColumnName("EMP_ENROLEMENT_TIME").HasDefaultValueSql("getdate()");
            entity.Property(e => e.DdoVerifyDate).HasColumnName("DDO_VERIFY_DATE");
            entity.Property(e => e.HrmsId).HasColumnName("HRMS_ID").HasMaxLength(50);
            entity.Property(e => e.WithoutHrmsDeput).HasColumnName("WITHOUT_HRMS_DEPUT").HasMaxLength(1);
            entity.Property(e => e.AadhaarNo).HasColumnName("EMP_ADHAR_NO");
            entity.Property(e => e.PayLevel).HasColumnName("PAY_LEVEL");
            entity.Property(e => e.BasicSalary).HasColumnName("BASIC_SALARY");
            entity.Property(e => e.WardTmc).HasColumnName("WARD_TMC");
            entity.Property(e => e.WardGovt).HasColumnName("WARD_GOVT");
            entity.Property(e => e.MemoNo).HasColumnName("MEMO_NO");
            entity.Property(e => e.MemoDate).HasColumnName("MEMO_DATE");
            entity.Property(e => e.ApproveUser).HasColumnName("APPROVE_USER");
            entity.Property(e => e.ApproverUserRoll).HasColumnName("APPROVER_USER_ROLL");
            entity.Property(e => e.ApproverName).HasColumnName("APPROVER_NAME");
            entity.Property(e => e.ApproverDesig).HasColumnName("APPROVER_DESIG");
            entity.Property(e => e.ApproverHoo).HasColumnName("APPROVER_HOO");
            entity.Property(e => e.BankName).HasColumnName("BANK_NAME");
            entity.Property(e => e.BankBranchName).HasColumnName("BANK_BRANCH_NAME");
            entity.Property(e => e.BankMicr).HasColumnName("BANK_MICR").HasMaxLength(50);
            entity.Property(e => e.BankAccountNo).HasColumnName("BANK_ACCNT_NO").HasMaxLength(20);
            entity.Property(e => e.BankIfsc).HasColumnName("BANK_IFSC");
            entity.Property(e => e.TempSuspendYsNo).HasColumnName("TEMP_SUSPEND_YS_NO").HasMaxLength(1);
            entity.Property(e => e.NonExistsBasicSalary).HasColumnName("NONEXISTS_BASIC_SALARY").HasMaxLength(10);
            entity.Property(e => e.SuspOrderNo).HasColumnName("SUSP_ORDER_NO");
            entity.Property(e => e.SuspOrderDate).HasColumnName("SUSP_ORDER_DATE");
            entity.Property(e => e.DateOfDeath).HasColumnName("DATE_OF_DEATH");
            entity.Property(e => e.OptOutAppId).HasColumnName("OPT_OUT_APP_ID").HasMaxLength(200);
        });

        modelBuilder.Entity<EmployeeOfficeLink>(entity =>
        {
            entity.ToTable("wbhs_linkwise_gpf_ONLINE", "dbo");
            entity.HasKey(e => new { e.EmpId, e.AppId });

            entity.Property(e => e.AppId).HasColumnName("APP_ID").HasMaxLength(200);
            entity.Property(e => e.EmpId).HasColumnName("empId").HasMaxLength(50);
            entity.Property(e => e.LocnFlg).HasColumnName("locn_flg").HasMaxLength(2);
            entity.Property(e => e.DeptCd).HasColumnName("dept_cd").HasMaxLength(10);
            entity.Property(e => e.NonExistsDte).HasColumnName("NONEXISTS_DTE");
            entity.Property(e => e.DteCd).HasColumnName("dte_cd").HasMaxLength(10);
            entity.Property(e => e.OffTypCd).HasColumnName("off_typ_cd").HasMaxLength(10);
            entity.Property(e => e.NonExistsAtch).HasColumnName("NONEXISTS_ATCH");
            entity.Property(e => e.AttachOffCd).HasColumnName("attach_off_cd").HasMaxLength(10);
            entity.Property(e => e.DstSdivBlk).HasColumnName("dst_sdiv_blk").HasMaxLength(50);
            entity.Property(e => e.NonExistsRegOfc).HasColumnName("NONEXISTS_REGOFC");
            entity.Property(e => e.RegOffCd).HasColumnName("reg_off_cd").HasMaxLength(10);
            entity.Property(e => e.OtherOfcCd).HasColumnName("other_ofc_cd").HasMaxLength(10);
            entity.Property(e => e.NonExistsOtherOfc).HasColumnName("NONEXISTS_OTHER_OFC");
            entity.Property(e => e.IsExists).HasColumnName("IS_EXISTS").HasMaxLength(1).IsRequired();
        });

        modelBuilder.Entity<EmployeeFamilyMember>(entity =>
        {
            entity.ToTable("wbhs_familyDetails_inservice_ONLINE", "dbo");
            entity.HasKey(e => new { e.IdNo, e.AppId });

            entity.Property(e => e.SerialNo).HasColumnName("Serial_no").ValueGeneratedOnAdd();
            entity.Property(e => e.AppId).HasColumnName("APP_ID").HasMaxLength(200);
            entity.Property(e => e.IdNo).HasColumnName("idno").HasMaxLength(70);
            entity.Property(e => e.Name).HasColumnName("bName").HasMaxLength(100);
            entity.Property(e => e.Age).HasColumnName("age").HasMaxLength(15);
            entity.Property(e => e.MemberCode).HasColumnName("mem_cd").HasMaxLength(2);
            entity.Property(e => e.MonthlyIncome).HasColumnName("monthIncome").HasMaxLength(10);
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.IsExists).HasColumnName("IS_EXISTS").HasMaxLength(1).IsRequired();
            entity.Property(e => e.Status).HasColumnName("status").HasMaxLength(1);
            entity.Property(e => e.DateOfDeath).HasColumnName("date_death");
            entity.Property(e => e.BenHrmsId).HasColumnName("BEN_HRMS_ID").HasMaxLength(14);
            entity.Property(e => e.TermCause).HasColumnName("TERM_CAUSE");
            entity.Property(e => e.TermDatetime).HasColumnName("TERM_DATETIME");
            entity.Property(e => e.EffectDatetime).HasColumnName("EFFECT_DATETIME");
            entity.Property(e => e.AadhaarNo).HasColumnName("MEM_ADHAR_NO");
            entity.Property(e => e.Category).HasColumnName("BEN_CAT").HasMaxLength(20);
            entity.Property(e => e.ValidUpTo).HasColumnName("Valid_UpTo");
            entity.Property(e => e.MobileNo).HasColumnName("MEM_MOB_NO").HasMaxLength(10);
            entity.Property(e => e.Email).HasColumnName("MEM_EMAIL_ID");
            entity.Property(e => e.WefDatetime).HasColumnName("WEF_DATETIME");
            entity.Property(e => e.FmlyPenAppId).HasColumnName("FMLY_PEN_APP_ID").HasMaxLength(200);
            entity.Property(e => e.FmlyPenPpoId).HasColumnName("FMLY_PEN_PPO_ID").HasMaxLength(70);
            entity.Property(e => e.FtpPhotoLocn).HasColumnName("FTP_PHOTO_LOCN");
            entity.Property(e => e.FtpSignLocn).HasColumnName("FTP_SIGN_LOCN");
            entity.Property(e => e.BloodGroup).HasColumnName("BEN_BLOOD_GROUP").HasMaxLength(4);
        });

        modelBuilder.Entity<EmployeeCcaLocation>(entity =>
        {
            entity.ToTable("wbhs_locnwise_cca_Inservice_ONLINE", "dbo");
            entity.HasKey(e => new { e.EmpId, e.AppId });

            entity.Property(e => e.AppId).HasColumnName("APP_ID").HasMaxLength(200);
            entity.Property(e => e.EmpId).HasColumnName("empId").HasMaxLength(50);
            entity.Property(e => e.LocnFlg).HasColumnName("locn_flg").HasMaxLength(2);
            entity.Property(e => e.DeptCd).HasColumnName("dept_cd").HasMaxLength(3);
            entity.Property(e => e.NonExistsDte).HasColumnName("NONEXISTS_DTE");
            entity.Property(e => e.DteCd).HasColumnName("dte_cd").HasMaxLength(3);
            entity.Property(e => e.OffTypCd).HasColumnName("off_typ_cd").HasMaxLength(2);
            entity.Property(e => e.NonExistsAtch).HasColumnName("NONEXISTS_ATCH");
            entity.Property(e => e.AttachOffCd).HasColumnName("attach_off_cd").HasMaxLength(3);
            entity.Property(e => e.DstSdivBlk).HasColumnName("dst_sdiv_blk").HasMaxLength(50);
            entity.Property(e => e.NonExistsRegOfc).HasColumnName("NONEXISTS_REGOFC");
            entity.Property(e => e.RegOffCd).HasColumnName("reg_off_cd").HasMaxLength(3);
            entity.Property(e => e.OtherOfcCd).HasColumnName("other_ofc_cd").HasMaxLength(3);
            entity.Property(e => e.NonExistsOtherOfc).HasColumnName("NONEXISTS_OTHER_OFC");
            entity.Property(e => e.NonExistsOrgDsg).HasColumnName("NONEXISTS_ORG_DSG");
            entity.Property(e => e.CadreCd).HasColumnName("cadre_cd").HasMaxLength(2);
            entity.Property(e => e.OrgDsgCd).HasColumnName("org_dsg_cd").HasMaxLength(3);
            entity.Property(e => e.IsExists).HasColumnName("IS_EXISTS").HasMaxLength(1).IsRequired();
        });

        modelBuilder.Entity<WbhsDdoEmpList>(entity =>
        {
            entity.ToTable("WBHS_DDO_EMP_LIST", "dbo");
            entity.HasKey(e => e.SlNo);
            entity.Property(e => e.SlNo).HasColumnName("sl_no").ValueGeneratedOnAdd();
            entity.Property(e => e.HrmsId).HasColumnName("HRMS_ID");
            entity.Property(e => e.EmployeeName).HasColumnName("EMPLOYEE_NAME");
            entity.Property(e => e.GpfNo).HasColumnName("GPF_NO");
            entity.Property(e => e.DdoCode).HasColumnName("DDO_CODE");
            entity.Property(e => e.DdoDesig).HasColumnName("DDO_DESIG");
        });

        modelBuilder.Entity<EmployeeMaster>(entity =>
        {
            entity.ToTable("wbhs_empBasicInfo", "dbo");
            entity.HasKey(e => e.EmpId);
            entity.Property(e => e.EmpId).HasColumnName("empId").HasMaxLength(50);
            entity.Property(e => e.EmpFirstName).HasColumnName("empFirstName").HasMaxLength(100);
            entity.Property(e => e.EmpLastName).HasColumnName("empLastName").HasMaxLength(100);
        });
    }
}
