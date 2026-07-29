using Portflio.ViewModels.Home;
using Portflio.ViewModels.Projects;

namespace Portflio.Services;

public interface IPortfolioContentProvider
{
    HomePageViewModel GetHomePage();
    ProjectsPageViewModel GetProjects(string? category = null);
    ProjectDetailsViewModel? GetProject(int id);
}
