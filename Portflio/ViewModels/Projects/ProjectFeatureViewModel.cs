using Portflio.ViewModels.Common;

namespace Portflio.ViewModels.Projects;

public sealed record ProjectFeatureViewModel(
    string Number,
    LocalizedTextViewModel Title,
    LocalizedTextViewModel Description);
