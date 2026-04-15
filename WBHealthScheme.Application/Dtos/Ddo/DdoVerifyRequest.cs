// ==========================================================
// DTO: DdoVerifyRequest
// Purpose: DDO approval request
// ==========================================================

namespace WBHealthScheme.Application.DTOs.Ddo;

public class DdoVerifyRequest
{
    public string ApplicationId { get; set; } = null!;
    public string DdoCode { get; set; } = null!;
}