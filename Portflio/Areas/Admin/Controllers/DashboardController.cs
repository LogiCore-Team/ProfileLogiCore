using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portflio.Areas.Admin.ViewModels;
using Portflio.Data;

namespace Portflio.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public sealed class DashboardController(ApplicationDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var model = new AdminDashboardViewModel(
            await dbContext.Projects.CountAsync(),
            await dbContext.Services.CountAsync(),
            await dbContext.Technologies.CountAsync(),
            await dbContext.TeamMembers.CountAsync(),
            await dbContext.StatItems.CountAsync(),
            await dbContext.Testimonials.CountAsync());

        return View(model);
    }
}
