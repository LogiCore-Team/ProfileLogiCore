using System.ComponentModel.DataAnnotations;

namespace Portflio.Data.Entities;

public sealed class StatItem
{
    public int Id { get; set; }

    [Required, StringLength(50)]
    public string Value { get; set; } = string.Empty;

    [Required, StringLength(200)]
    public string LabelAr { get; set; } = string.Empty;

    [Required, StringLength(200)]
    public string LabelEn { get; set; } = string.Empty;

    [Range(0, int.MaxValue)]
    public int DisplayOrder { get; set; }
}
