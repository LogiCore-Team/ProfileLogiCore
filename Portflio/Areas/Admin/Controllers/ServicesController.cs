using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portflio.Data;
using Portflio.Data.Entities;

namespace Portflio.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public sealed class ServicesController(ApplicationDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index() =>
        View(await dbContext.Services.AsNoTracking()
            .OrderBy(service => service.DisplayOrder)
            .ThenBy(service => service.TitleEn)
            .ToListAsync());

    public async Task<IActionResult> Details(int id)
    {
        var service = await dbContext.Services.AsNoTracking()
            .SingleOrDefaultAsync(item => item.Id == id);
        return service is null ? NotFound() : View(service);
    }

    public IActionResult Create() => View(new Service());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("TitleAr,TitleEn,DescriptionAr,DescriptionEn,IconClass,DisplayOrder,IsActive")]
        Service service)
    {
        if (!ModelState.IsValid)
        {
            return View(service);
        }

        dbContext.Services.Add(service);
        await dbContext.SaveChangesAsync();
        TempData["SuccessMessage"] = $"تم إنشاء الخدمة «{service.TitleAr}» بنجاح.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var service = await dbContext.Services.FindAsync(id);
        return service is null ? NotFound() : View(service);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id,
        [Bind("Id,TitleAr,TitleEn,DescriptionAr,DescriptionEn,IconClass,DisplayOrder,IsActive")]
        Service service)
    {
        if (id != service.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(service);
        }

        if (!await dbContext.Services.AnyAsync(item => item.Id == id))
        {
            return NotFound();
        }

        dbContext.Update(service);
        await dbContext.SaveChangesAsync();
        TempData["SuccessMessage"] = $"تم تحديث الخدمة «{service.TitleAr}» بنجاح.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var service = await dbContext.Services.AsNoTracking()
            .SingleOrDefaultAsync(item => item.Id == id);
        return service is null ? NotFound() : View(service);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var service = await dbContext.Services.FindAsync(id);
        if (service is null)
        {
            return NotFound();
        }

        dbContext.Services.Remove(service);
        await dbContext.SaveChangesAsync();
        TempData["SuccessMessage"] = $"تم حذف الخدمة «{service.TitleAr}» بنجاح.";
        return RedirectToAction(nameof(Index));
    }
}
