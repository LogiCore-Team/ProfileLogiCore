using Portflio.ViewModels.Projects;

namespace Portflio.ViewModels.Home;

public sealed record HomePageViewModel(
    IReadOnlyList<ServiceViewModel> Services,
    IReadOnlyList<TechnologyViewModel> Technologies,
    IReadOnlyList<FilterOptionViewModel> TechnologyCategories,
    IReadOnlyList<ProjectCardViewModel> FeaturedProjects,
    IReadOnlyList<FilterOptionViewModel> ProjectCategories,
    IReadOnlyList<TeamMemberViewModel> TeamMembers,
    IReadOnlyList<TestimonialViewModel> Testimonials,
    IReadOnlyList<StatViewModel> Stats);
