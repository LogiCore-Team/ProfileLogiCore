using Portflio.ViewModels.Common;
using Portflio.ViewModels.Home;

namespace Portflio.ViewModels.Projects;

public sealed record ProjectDetailsViewModel(
    int Id,
    string CategoryKey,
    LocalizedTextViewModel Category,
    LocalizedTextViewModel Title,
    LocalizedTextViewModel Summary,
    string Client,
    LocalizedTextViewModel Duration,
    string Year,
    string LiveDemoUrl,
    string RepositoryUrl,
    IReadOnlyList<ProjectMediaViewModel> Media,
    LocalizedTextViewModel ProblemStatement,
    LocalizedTextViewModel DeliveredSolution,
    IReadOnlyList<ProjectFeatureViewModel> KeyFeatures,
    IReadOnlyList<TechnologyViewModel> Technologies);
