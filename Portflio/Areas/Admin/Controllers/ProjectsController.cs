using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portflio.Areas.Admin.ViewModels;
using Portflio.Data;
using Portflio.Data.Entities;

namespace Portflio.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public sealed class ProjectsController(ApplicationDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var projects = await dbContext.Projects
            .AsNoTracking()
            .Include(project => project.ProjectTechnologies)
                .ThenInclude(item => item.Technology)
            .OrderByDescending(project => project.CreatedAt)
            .ToListAsync();

        return View(projects);
    }

    public async Task<IActionResult> Details(int id)
    {
        var project = await FindProjectAsync(id, tracking: false);
        return project is null ? NotFound() : View(project);
    }

    public async Task<IActionResult> Create()
    {
        var model = new ProjectFormViewModel();
        await LoadTechnologiesAsync(model);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProjectFormViewModel model)
    {
        await ValidateTechnologySelectionAsync(model.SelectedTechnologyIds);

        if (!ModelState.IsValid)
        {
            await LoadTechnologiesAsync(model);
            return View(model);
        }

        var project = new Project
        {
            CreatedAt = DateTime.UtcNow
        };

        MapProject(model, project);
        AddProjectChildren(model, project);

        dbContext.Projects.Add(project);
        await dbContext.SaveChangesAsync();

        TempData["SuccessMessage"] = $"تم إنشاء المشروع «{project.TitleAr}» بنجاح.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var project = await FindProjectAsync(id, tracking: false);
        if (project is null)
        {
            return NotFound();
        }

        var model = ToFormModel(project);
        await LoadTechnologiesAsync(model);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ProjectFormViewModel model)
    {
        if (id != model.Id)
        {
            return BadRequest();
        }

        await ValidateTechnologySelectionAsync(model.SelectedTechnologyIds);

        if (!ModelState.IsValid)
        {
            await LoadTechnologiesAsync(model);
            return View(model);
        }

        var project = await FindProjectAsync(id, tracking: true);
        if (project is null)
        {
            return NotFound();
        }

        MapProject(model, project);
        ReplaceProjectChildren(model, project);
        SynchronizeTechnologies(model.SelectedTechnologyIds, project);

        await dbContext.SaveChangesAsync();

        TempData["SuccessMessage"] = $"تم تحديث المشروع «{project.TitleAr}» بنجاح.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var project = await FindProjectAsync(id, tracking: false);
        return project is null ? NotFound() : View(project);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var project = await dbContext.Projects.FindAsync(id);
        if (project is null)
        {
            return NotFound();
        }

        dbContext.Projects.Remove(project);
        await dbContext.SaveChangesAsync();

        TempData["SuccessMessage"] = $"تم حذف المشروع «{project.TitleAr}» بنجاح.";
        return RedirectToAction(nameof(Index));
    }

    private async Task<Project?> FindProjectAsync(int id, bool tracking)
    {
        var query = dbContext.Projects
            .Include(project => project.Features)
            .Include(project => project.Media)
            .Include(project => project.ProjectTechnologies)
                .ThenInclude(item => item.Technology)
            .AsQueryable();

        if (!tracking)
        {
            query = query.AsNoTracking();
        }

        return await query.SingleOrDefaultAsync(project => project.Id == id);
    }

    private async Task LoadTechnologiesAsync(ProjectFormViewModel model)
    {
        model.AvailableTechnologies = await dbContext.Technologies
            .AsNoTracking()
            .OrderBy(technology => technology.Name)
            .Select(technology => new TechnologyOptionViewModel
            {
                Id = technology.Id,
                Name = technology.Name
            })
            .ToListAsync();
    }

    private async Task ValidateTechnologySelectionAsync(IEnumerable<int> selectedIds)
    {
        var ids = selectedIds.Distinct().ToArray();
        if (ids.Length == 0)
        {
            return;
        }

        var validCount = await dbContext.Technologies.CountAsync(item => ids.Contains(item.Id));
        if (validCount != ids.Length)
        {
            ModelState.AddModelError(
                nameof(ProjectFormViewModel.SelectedTechnologyIds),
                "تقنية واحدة أو أكثر من التقنيات المحددة غير صالحة.");
        }
    }

    private static void MapProject(ProjectFormViewModel model, Project project)
    {
        project.TitleEn = model.TitleEn.Trim();
        project.TitleAr = model.TitleAr.Trim();
        project.ShortDescriptionEn = model.ShortDescriptionEn.Trim();
        project.ShortDescriptionAr = model.ShortDescriptionAr.Trim();
        project.FullDescriptionEn = model.FullDescriptionEn.Trim();
        project.FullDescriptionAr = model.FullDescriptionAr.Trim();
        project.ClientName = model.ClientName.Trim();
        project.Category = model.Category.Trim();
        project.CoverImageUrl = NormalizeOptional(model.CoverImageUrl);
        project.LiveDemoUrl = NormalizeOptional(model.LiveDemoUrl);
        project.RepoUrl = NormalizeOptional(model.RepoUrl);
        project.IsFeatured = model.IsFeatured;
    }

    private static void AddProjectChildren(ProjectFormViewModel model, Project project)
    {
        foreach (var feature in model.Features)
        {
            project.Features.Add(new ProjectFeature
            {
                FeatureTextEn = feature.FeatureTextEn.Trim(),
                FeatureTextAr = feature.FeatureTextAr.Trim(),
                DisplayOrder = feature.DisplayOrder
            });
        }

        foreach (var media in model.Media)
        {
            project.Media.Add(new ProjectMedia
            {
                MediaUrl = media.MediaUrl.Trim(),
                MediaType = media.MediaType,
                DisplayOrder = media.DisplayOrder
            });
        }

        foreach (var technologyId in model.SelectedTechnologyIds.Distinct())
        {
            project.ProjectTechnologies.Add(new ProjectTechnology
            {
                TechnologyId = technologyId
            });
        }
    }

    private void ReplaceProjectChildren(ProjectFormViewModel model, Project project)
    {
        dbContext.ProjectFeatures.RemoveRange(project.Features);
        dbContext.ProjectMedia.RemoveRange(project.Media);
        project.Features.Clear();
        project.Media.Clear();

        AddFeaturesAndMedia(model, project);
    }

    private static void AddFeaturesAndMedia(ProjectFormViewModel model, Project project)
    {
        foreach (var feature in model.Features)
        {
            project.Features.Add(new ProjectFeature
            {
                FeatureTextEn = feature.FeatureTextEn.Trim(),
                FeatureTextAr = feature.FeatureTextAr.Trim(),
                DisplayOrder = feature.DisplayOrder
            });
        }

        foreach (var media in model.Media)
        {
            project.Media.Add(new ProjectMedia
            {
                MediaUrl = media.MediaUrl.Trim(),
                MediaType = media.MediaType,
                DisplayOrder = media.DisplayOrder
            });
        }
    }

    private void SynchronizeTechnologies(IEnumerable<int> selectedIds, Project project)
    {
        var requestedIds = selectedIds.Distinct().ToHashSet();
        var removedLinks = project.ProjectTechnologies
            .Where(item => !requestedIds.Contains(item.TechnologyId))
            .ToList();

        dbContext.ProjectTechnologies.RemoveRange(removedLinks);

        var existingIds = project.ProjectTechnologies
            .Select(item => item.TechnologyId)
            .ToHashSet();

        foreach (var technologyId in requestedIds.Except(existingIds))
        {
            project.ProjectTechnologies.Add(new ProjectTechnology
            {
                ProjectId = project.Id,
                TechnologyId = technologyId
            });
        }
    }

    private static ProjectFormViewModel ToFormModel(Project project)
    {
        return new ProjectFormViewModel
        {
            Id = project.Id,
            TitleEn = project.TitleEn,
            TitleAr = project.TitleAr,
            ShortDescriptionEn = project.ShortDescriptionEn,
            ShortDescriptionAr = project.ShortDescriptionAr,
            FullDescriptionEn = project.FullDescriptionEn,
            FullDescriptionAr = project.FullDescriptionAr,
            ClientName = project.ClientName,
            Category = project.Category,
            CoverImageUrl = project.CoverImageUrl,
            LiveDemoUrl = project.LiveDemoUrl,
            RepoUrl = project.RepoUrl,
            IsFeatured = project.IsFeatured,
            SelectedTechnologyIds = project.ProjectTechnologies
                .Select(item => item.TechnologyId)
                .ToList(),
            Features = project.Features
                .OrderBy(item => item.DisplayOrder)
                .Select(item => new ProjectFeatureInputModel
                {
                    Id = item.Id,
                    FeatureTextEn = item.FeatureTextEn,
                    FeatureTextAr = item.FeatureTextAr,
                    DisplayOrder = item.DisplayOrder
                })
                .ToList(),
            Media = project.Media
                .OrderBy(item => item.DisplayOrder)
                .Select(item => new ProjectMediaInputModel
                {
                    Id = item.Id,
                    MediaUrl = item.MediaUrl,
                    MediaType = item.MediaType,
                    DisplayOrder = item.DisplayOrder
                })
                .ToList()
        };
    }

    private static string? NormalizeOptional(string? value) =>
        string.IsNullOrWhiteSpace(value) ? null : value.Trim();
}
