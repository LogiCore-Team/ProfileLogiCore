using System.ComponentModel.DataAnnotations;

namespace Portflio.Data.Entities;

public sealed class ProjectFeature
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    [Required, StringLength(500)]
    public string FeatureTextAr { get; set; } = string.Empty;

    [Required, StringLength(500)]
    public string FeatureTextEn { get; set; } = string.Empty;
    public int DisplayOrder { get; set; }

    public Project Project { get; set; } = null!;
}
