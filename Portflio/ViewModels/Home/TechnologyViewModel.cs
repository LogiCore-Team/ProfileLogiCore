using Portflio.ViewModels.Common;

namespace Portflio.ViewModels.Home;

public sealed record TechnologyViewModel(
    string Name,
    string CategoryKey,
    LocalizedTextViewModel Note,
    string? IconSvg = null,
    string? ImageUrl = null,
    string? IconClass = null);
