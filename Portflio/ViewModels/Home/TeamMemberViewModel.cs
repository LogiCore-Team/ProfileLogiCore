using Portflio.ViewModels.Common;

namespace Portflio.ViewModels.Home;

public sealed record TeamMemberViewModel(
    string Initials,
    LocalizedTextViewModel Name,
    LocalizedTextViewModel Role,
    IReadOnlyList<string> Skills,
    string GitHubUrl,
    string LinkedInUrl);
