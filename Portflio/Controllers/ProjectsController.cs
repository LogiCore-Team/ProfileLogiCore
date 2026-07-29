using Microsoft.AspNetCore.Mvc;
using Portflio.Services;

namespace Portflio.Controllers;

public sealed class ProjectsController : Controller
{
    private readonly IPortfolioContentProvider _contentProvider;

    public ProjectsController(IPortfolioContentProvider contentProvider)
    {
        _contentProvider = contentProvider;
    }

    [HttpGet("/Projects")]
    public IActionResult Index(string? category = null)
    {
        return View("Projects", _contentProvider.GetProjects(category));
    }

    [HttpGet("/Projects/Details/{id:int}")]
    public IActionResult Details(int id)
    {
        var project = _contentProvider.GetProject(id);
        return project is null ? NotFound() : View("ProjectDetails", project);
    }
}
