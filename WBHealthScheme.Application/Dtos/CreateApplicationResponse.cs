namespace WBHealthScheme.Application.DTOs;

public class CreateApplicationResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = null!;
    public object Data { get; set; } = null!;
}
