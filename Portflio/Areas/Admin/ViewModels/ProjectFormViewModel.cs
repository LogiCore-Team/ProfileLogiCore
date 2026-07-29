using System.ComponentModel.DataAnnotations;
using Portflio.Data.Entities;

namespace Portflio.Areas.Admin.ViewModels;

public sealed class ProjectFormViewModel
{
    public int Id { get; set; }

    [Required, StringLength(200), Display(Name = "English title")]
    public string TitleEn { get; set; } = string.Empty;

    [Required, StringLength(200), Display(Name = "Arabic title")]
    public string TitleAr { get; set; } = string.Empty;

    [Required, StringLength(500), Display(Name = "English short description")]
    public string ShortDescriptionEn { get; set; } = string.Empty;

    [Required, StringLength(500), Display(Name = "Arabic short description")]
    public string ShortDescriptionAr { get; set; } = string.Empty;

    [Required, StringLength(4000), Display(Name = "English full description")]
    public string FullDescriptionEn { get; set; } = string.Empty;

    [Required, StringLength(4000), Display(Name = "Arabic full description")]
    public string FullDescriptionAr { get; set; } = string.Empty;

    [Required, StringLength(200), Display(Name = "Client name")]
    public string ClientName { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Category { get; set; } = string.Empty;

    [Url, StringLength(2048), Display(Name = "Cover image URL")]
    public string? CoverImageUrl { get; set; }

    [Url, StringLength(2048), Display(Name = "Live demo URL")]
    public string? LiveDemoUrl { get; set; }

    [Url, StringLength(2048), Display(Name = "Repository URL")]
    public string? RepoUrl { get; set; }

    [Display(Name = "Featured project")]
    public bool IsFeatured { get; set; }

    public List<int> SelectedTechnologyIds { get; set; } = [];
    public List<TechnologyOptionViewModel> AvailableTechnologies { get; set; } = [];
    public List<ProjectFeatureInputModel> Features { get; set; } = [];
    public List<ProjectMediaInputModel> Media { get; set; } = [];
}

public sealed class TechnologyOptionViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public sealed class ProjectFeatureInputModel
{
    public int Id { get; set; }

    [Required, StringLength(500), Display(Name = "English feature")]
    public string FeatureTextEn { get; set; } = string.Empty;

    [Required, StringLength(500), Display(Name = "Arabic feature")]
    public string FeatureTextAr { get; set; } = string.Empty;

    [Range(0, int.MaxValue), Display(Name = "Display order")]
    public int DisplayOrder { get; set; }
}

public sealed class ProjectMediaInputModel
{
    public int Id { get; set; }

    [Required, Url, StringLength(2048), Display(Name = "Media URL")]
    public string MediaUrl { get; set; } = string.Empty;

    [EnumDataType(typeof(MediaType)), Display(Name = "Media type")]
    public MediaType MediaType { get; set; } = MediaType.Image;

    [Range(0, int.MaxValue), Display(Name = "Display order")]
    public int DisplayOrder { get; set; }
}
