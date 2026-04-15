namespace WBHealthScheme.Application.DTOs;

public class CreateApplicationRequest
{
    public string LocationCode { get; set; } = null!;

    public string EmpId { get; set; } = null!;

    public DateTime DateOfJoining { get; set; }

    // true = employee already has GPF/PRAN, false = generate NONGPF
    public bool HasGpf { get; set; }

    // Required only when HasGpf = true
    public string? GpfNo { get; set; }
}
