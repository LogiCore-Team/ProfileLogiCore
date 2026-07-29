using Microsoft.EntityFrameworkCore;
using Portflio.Data;
using Portflio.Data.Entities;
using Portflio.ViewModels.Common;
using Portflio.ViewModels.Home;
using Portflio.ViewModels.Projects;

namespace Portflio.Services;

public sealed class SqlPortfolioContentProvider(ApplicationDbContext dbContext)
    : IPortfolioContentProvider
{
    public HomePageViewModel GetHomePage()
    {
        var projects = dbContext.Projects
            .AsNoTracking()
            .Where(project => project.IsFeatured)
            .OrderByDescending(project => project.CreatedAt)
            .Include(project => project.ProjectTechnologies)
                .ThenInclude(item => item.Technology)
            .ToList();

        var services = dbContext.Services
            .AsNoTracking()
            .Where(service => service.IsActive)
            .OrderBy(service => service.DisplayOrder)
            .ThenBy(service => service.Id)
            .Select(service => new ServiceViewModel(
                service.IconClass ?? string.Empty,
                L(service.TitleEn, service.TitleAr),
                L(service.DescriptionEn, service.DescriptionAr)))
            .ToList();

        var technologies = dbContext.Technologies
            .AsNoTracking()
            .OrderBy(technology => technology.Name)
            .Select(technology => new TechnologyViewModel(
                technology.Name,
                "all",
                L(technology.IconClass ?? string.Empty, technology.IconClass ?? string.Empty)))
            .ToList();

        var teamMembers = dbContext.TeamMembers
            .AsNoTracking()
            .Where(member => member.IsActive)
            .OrderBy(member => member.DisplayOrder)
            .ThenBy(member => member.Id)
            .ToList()
            .Select(member => new TeamMemberViewModel(
                GetInitials(member.NameEn),
                L(member.NameEn, member.NameAr),
                L(member.RoleEn, member.RoleAr),
                ParseSkills(member.SkillsCsv),
                member.GitHubUrl ?? string.Empty,
                member.LinkedInUrl ?? string.Empty))
            .ToList();

        var stats = dbContext.StatItems
            .AsNoTracking()
            .OrderBy(stat => stat.DisplayOrder)
            .ThenBy(stat => stat.Id)
            .Select(stat => new StatViewModel(
                stat.Value,
                L(stat.LabelEn, stat.LabelAr)))
            .ToList();

        return new HomePageViewModel(
            services,
            technologies,
            [],
            projects.Select(ToCard).ToList(),
            BuildCategoryFilters(projects.Select(project => project.Category)),
            teamMembers,
            [],
            stats);
    }

    public ProjectsPageViewModel GetProjects(string? category = null)
    {
        var projects = dbContext.Projects
            .AsNoTracking()
            .OrderByDescending(project => project.CreatedAt)
            .Include(project => project.ProjectTechnologies)
                .ThenInclude(item => item.Technology)
            .ToList();

        var categories = BuildCategoryFilters(projects.Select(project => project.Category));
        var normalizedCategory = categories.Any(item =>
            string.Equals(item.Key, category, StringComparison.OrdinalIgnoreCase))
                ? category!.ToLowerInvariant()
                : "all";

        return new ProjectsPageViewModel(
            categories,
            projects.Select(ToCard).ToList(),
            normalizedCategory);
    }

    public ProjectDetailsViewModel? GetProject(int id)
    {
        var project = dbContext.Projects
            .AsNoTracking()
            .Include(item => item.Media)
            .Include(item => item.Features)
            .Include(item => item.ProjectTechnologies)
                .ThenInclude(item => item.Technology)
            .SingleOrDefault(item => item.Id == id);

        if (project is null)
        {
            return null;
        }

        var media = project.Media
            .OrderBy(item => item.DisplayOrder)
            .ThenBy(item => item.Id)
            .Select(item => new ProjectMediaViewModel(
                ToVisualVariant(item.MediaUrl, item.MediaType),
                L(item.MediaType.ToString(), item.MediaType.ToString()),
                L(item.MediaUrl, item.MediaUrl)))
            .ToList();

        var features = project.Features
            .OrderBy(item => item.DisplayOrder)
            .ThenBy(item => item.Id)
            .Select((item, index) => new ProjectFeatureViewModel(
                (index + 1).ToString("00"),
                L(item.FeatureTextEn, item.FeatureTextAr),
                L(string.Empty, string.Empty)))
            .ToList();

        var technologies = project.ProjectTechnologies
            .Select(item => item.Technology)
            .OrderBy(technology => technology.Name)
            .Select(technology => new TechnologyViewModel(
                technology.Name,
                "all",
                L(technology.IconClass ?? string.Empty, technology.IconClass ?? string.Empty)))
            .ToList();

        return new ProjectDetailsViewModel(
            project.Id,
            NormalizeKey(project.Category),
            L(project.Category, project.Category),
            L(project.TitleEn, project.TitleAr),
            L(project.ShortDescriptionEn, project.ShortDescriptionAr),
            project.ClientName,
            L(string.Empty, string.Empty),
            project.CreatedAt.Year.ToString(),
            project.LiveDemoUrl ?? string.Empty,
            project.RepoUrl ?? string.Empty,
            media,
            L(project.FullDescriptionEn, project.FullDescriptionAr),
            L(project.FullDescriptionEn, project.FullDescriptionAr),
            features,
            technologies);
    }

    private static ProjectCardViewModel ToCard(Project project)
    {
        return new ProjectCardViewModel(
            project.Id,
            NormalizeKey(project.Category),
            L(project.Category, project.Category),
            L(project.TitleEn, project.TitleAr),
            L(project.ShortDescriptionEn, project.ShortDescriptionAr),
            project.ClientName,
            project.CreatedAt.Year.ToString(),
            ToVisualVariant(project.CoverImageUrl, MediaType.Image),
            project.ProjectTechnologies
                .Select(item => item.Technology.Name)
                .OrderBy(name => name)
                .ToList());
    }

    private static IReadOnlyList<FilterOptionViewModel> BuildCategoryFilters(
        IEnumerable<string> categories)
    {
        return categories
            .Where(category => !string.IsNullOrWhiteSpace(category))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(category => category)
            .Select(category => new FilterOptionViewModel(
                NormalizeKey(category),
                L(category, category)))
            .ToList();
    }

    private static string[] ParseSkills(string? skillsCsv)
    {
        return string.IsNullOrWhiteSpace(skillsCsv)
            ? []
            : skillsCsv.Split(
                ',',
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    }

    private static string GetInitials(string name)
    {
        var parts = name.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        return string.Concat(parts.Take(2).Select(part => char.ToUpperInvariant(part[0])));
    }

    private static string ToVisualVariant(string? value, MediaType mediaType)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return mediaType == MediaType.Video ? "video" : "project";
        }

        var fileName = Path.GetFileNameWithoutExtension(value);
        return NormalizeKey(string.IsNullOrWhiteSpace(fileName) ? "project" : fileName);
    }

    private static string NormalizeKey(string value)
    {
        var characters = value
            .Trim()
            .ToLowerInvariant()
            .Select(character => char.IsLetterOrDigit(character) ? character : '-')
            .ToArray();

        return string.Join(
            '-',
            new string(characters).Split('-', StringSplitOptions.RemoveEmptyEntries));
    }

    private static LocalizedTextViewModel L(string english, string arabic) =>
        new(english, arabic);
}
