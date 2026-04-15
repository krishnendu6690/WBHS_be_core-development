// ==========================================================
// Entity: EmployeeMaster
// Purpose: Maps to wbhs.wbhs_empbasicinfo (Master Table)
// Layer: Domain
// ==========================================================

namespace WBHealthScheme.Domain.Entities;

public class EmployeeMaster
{
    public string EmpId { get; set; } = null!;
    public string? EmpFirstName { get; set; }
    public string? EmpLastName { get; set; }
}