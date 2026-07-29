using Portflio.ViewModels.Common;

namespace Portflio.ViewModels.Home;

public sealed record StatViewModel(
    string Value,
    LocalizedTextViewModel Label);
