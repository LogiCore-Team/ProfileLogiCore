namespace Portflio.ViewModels.Projects;

public sealed record ProjectsPageViewModel(
    IReadOnlyList<FilterOptionViewModel> Categories,
    IReadOnlyList<ProjectCardViewModel> Projects,
    string SelectedCategory);
