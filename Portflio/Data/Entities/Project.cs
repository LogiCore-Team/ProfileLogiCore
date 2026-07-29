using System.ComponentModel.DataAnnotations;

namespace Portflio.Data.Entities;

public sealed class Project
{
    public int Id { get; set; }

    [Required, StringLength(200)]
    public string TitleAr { get; set; } = string.Empty;

    [Required, StringLength(200)]
    public string TitleEn { get; set; } = string.Empty;

    [Required, StringLength(500)]
    public string ShortDescriptionAr { get; set; } = string.Empty;

    [Required, StringLength(500)]
    public string ShortDescriptionEn { get; set; } = string.Empty;

    [Required, StringLength(4000)]
    public string FullDescriptionAr { get; set; } = string.Empty;

    [Required, StringLength(4000)]
    public string FullDescriptionEn { get; set; } = string.Empty;

    [Required, StringLength(200)]
    public string ClientName { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Category { get; set; } = string.Empty;

    [Url, StringLength(2048)]
    public string? CoverImageUrl { get; set; }

    [Url, StringLength(2048)]
    public string? LiveDemoUrl { get; set; }

    [Url, StringLength(2048)]
    public string? RepoUrl { get; set; }

    public DateTime CreatedAt { get; set; }
    public bool IsFeatured { get; set; }

    public ICollection<ProjectMedia> Media { get; set; } = [];
    public ICollection<ProjectFeature> Features { get; set; } = [];
    public ICollection<ProjectTechnology> ProjectTechnologies { get; set; } = [];
}
