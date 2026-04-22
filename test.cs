using Microsoft.EntityFrameworkCore;
using WBHealthScheme.Domain.Entities;

namespace WBHealthScheme.Infrastructure.Persistence;

public class WBHSDbContext : DbContext
{
    public WBHSDbContext(DbContextOptions<WBHSDbContext> options) : base(options) { }

    public DbSet<WbhsApplicationIdEmpOnline> EmployeeApplications => Set<WbhsApplicationIdEmpOnline>();
 
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

       
   
        
    }
}