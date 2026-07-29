using Portflio.ViewModels.Common;

namespace Portflio.ViewModels.Home;

public sealed record ServiceViewModel(
    string Icon,
    LocalizedTextViewModel Title,
    LocalizedTextViewModel Description);
