using Microsoft.AspNetCore.Http;

namespace WBHealthScheme.API.Models;

/// <summary>
/// API model for file upload request
/// </summary>
public class UploadFamilyPhotoRequest
{
    public string AppId { get; set; }

    public string IdNo { get; set; }

    public IFormFile Photo { get; set; }

    public IFormFile Signature { get; set; }
}