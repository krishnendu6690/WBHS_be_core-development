// ==========================================================
// DTO: ApplicationDetailsResponse
// Purpose : Aggregated application details for verification
// Layer   : Application
// ==========================================================

using WBHealthScheme.Domain.Entities;

namespace WBHealthScheme.Application.DTOs;

/// <summary>
/// Complete application details response
/// </summary>
public class ApplicationDetailsResponse
{
    /// <summary>
    /// Application metadata
    /// </summary>
    public WbhsApplicationIdEmpOnline? Application { get; set; }

    /// <summary>
    /// Personal information
    /// </summary>
    public EmployeeBasicInfo? PersonalDetails { get; set; }

    /// <summary>
    /// Office information
    /// </summary>
    public EmployeeOfficeLink? OfficeDetails { get; set; }

    /// <summary>
    /// CCA / Head of Office information
    /// </summary>
    public EmployeeCcaLocation? CcaDetails { get; set; }

    /// <summary>
    /// Family member list
    /// </summary>
    public List<EmployeeFamilyMember> FamilyMembers { get; set; } = new();
}