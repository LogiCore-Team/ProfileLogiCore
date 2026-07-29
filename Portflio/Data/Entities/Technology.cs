using System.ComponentModel.DataAnnotations;

namespace Portflio.Data.Entities;

public sealed class Technology
{
    public int Id { get; set; }
    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(200)]
    public string? IconClass { get; set; }

    [Url, StringLength(2048)]
    public string? ImageUrl { get; set; }

    public ICollection<ProjectTechnology> ProjectTechnologies { get; set; } = [];
}
