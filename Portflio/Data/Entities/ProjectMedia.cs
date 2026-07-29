using System.ComponentModel.DataAnnotations;

namespace Portflio.Data.Entities;

public sealed class ProjectMedia
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    [Required, Url, StringLength(2048)]
    public string MediaUrl { get; set; } = string.Empty;
    public MediaType MediaType { get; set; }
    public int DisplayOrder { get; set; }

    public Project Project { get; set; } = null!;
}
