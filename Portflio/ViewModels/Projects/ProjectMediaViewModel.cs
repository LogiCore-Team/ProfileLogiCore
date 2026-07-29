using Portflio.ViewModels.Common;

namespace Portflio.ViewModels.Projects;

public sealed record ProjectMediaViewModel(
    string VisualVariant,
    LocalizedTextViewModel Title,
    LocalizedTextViewModel Caption);
