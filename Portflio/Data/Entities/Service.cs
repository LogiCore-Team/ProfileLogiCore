using System.ComponentModel.DataAnnotations;

namespace Portflio.Data.Entities;

public sealed class Service
{
    public int Id { get; set; }
    [Required, StringLength(200)]
    public string TitleAr { get; set; } = string.Empty;

    [Required, StringLength(200)]
    public string TitleEn { get; set; } = string.Empty;

    [Required, StringLength(1000)]
    public string DescriptionAr { get; set; } = string.Empty;

    [Required, StringLength(1000)]
    public string DescriptionEn { get; set; } = string.Empty;

    [StringLength(200)]
    public string? IconClass { get; set; }

    [Range(0, int.MaxValue)]
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; } = true;
}
