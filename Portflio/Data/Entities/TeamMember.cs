using System.ComponentModel.DataAnnotations;

namespace Portflio.Data.Entities;

public sealed class TeamMember
{
    public int Id { get; set; }
    [Required, StringLength(200)]
    public string NameAr { get; set; } = string.Empty;

    [Required, StringLength(200)]
    public string NameEn { get; set; } = string.Empty;

    [Required, StringLength(200)]
    public string RoleAr { get; set; } = string.Empty;

    [Required, StringLength(200)]
    public string RoleEn { get; set; } = string.Empty;

    [Url, StringLength(2048)]
    public string? ProfileImageUrl { get; set; }

    [StringLength(1000)]
    public string? SkillsCsv { get; set; }

    [Url, StringLength(2048)]
    public string? GitHubUrl { get; set; }

    [Url, StringLength(2048)]
    public string? LinkedInUrl { get; set; }

    [Range(0, int.MaxValue)]
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; } = true;
}
