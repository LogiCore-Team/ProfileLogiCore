using Portflio.ViewModels.Common;

namespace Portflio.ViewModels.Projects;

public sealed record ProjectCardViewModel(
    int Id,
    string CategoryKey,
    LocalizedTextViewModel Category,
    LocalizedTextViewModel Title,
    LocalizedTextViewModel Summary,
    string Client,
    string Year,
    string VisualVariant,
    IReadOnlyList<string> Technologies);
