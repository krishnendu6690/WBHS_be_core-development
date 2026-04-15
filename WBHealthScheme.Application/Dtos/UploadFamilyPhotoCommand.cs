namespace WBHealthScheme.Application.DTOs;

/// <summary>
/// Command used by Application layer to upload family photo/signature
/// Framework-independent (Clean Architecture)
/// </summary>
public class UploadFamilyPhotoCommand
{
    public required string AppId { get; set; }

    public required string IdNo { get; set; }

    public required byte[] PhotoBytes { get; set; }

    public required byte[] SignatureBytes { get; set; }

    public required string PhotoFileName { get; set; }

    public required string SignatureFileName { get; set; }
}