using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portflio.Data;
using Portflio.Data.Entities;
using Portflio.Services;

namespace Portflio.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public sealed class TechnologiesController(ApplicationDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index() =>
        View(await dbContext.Technologies.AsNoTracking()
            .Include(technology => technology.ProjectTechnologies)
            .OrderBy(technology => technology.Name)
            .ToListAsync());

    public async Task<IActionResult> Details(int id)
    {
        var technology = await FindTechnologyAsync(id);
        return technology is null ? NotFound() : View(technology);
    }

    public IActionResult Create() => View(new Technology());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Name,IconClass,ImageUrl,IconSvg")] Technology technology)
    {
        await ValidateUniqueNameAsync(technology.Name);
        ProcessSvgInput(technology);

        if (!ModelState.IsValid)
        {
            return View(technology);
        }

        technology.Name = technology.Name.Trim();
        dbContext.Technologies.Add(technology);
        await dbContext.SaveChangesAsync();
        TempData["SuccessMessage"] = $"تم إنشاء التقنية «{technology.Name}» بنجاح.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var technology = await dbContext.Technologies.FindAsync(id);
        return technology is null ? NotFound() : View(technology);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id,
        [Bind("Id,Name,IconClass,ImageUrl,IconSvg")] Technology technology)
    {
        if (id != technology.Id)
        {
            return BadRequest();
        }

        await ValidateUniqueNameAsync(technology.Name, technology.Id);
        ProcessSvgInput(technology);

        if (!ModelState.IsValid)
        {
            return View(technology);
        }

        if (!await dbContext.Technologies.AnyAsync(item => item.Id == id))
        {
            return NotFound();
        }

        technology.Name = technology.Name.Trim();
        dbContext.Update(technology);
        await dbContext.SaveChangesAsync();
        TempData["SuccessMessage"] = $"تم تحديث التقنية «{technology.Name}» بنجاح.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var technology = await FindTechnologyAsync(id);
        return technology is null ? NotFound() : View(technology);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var technology = await dbContext.Technologies.FindAsync(id);
        if (technology is null)
        {
            return NotFound();
        }

        dbContext.Technologies.Remove(technology);
        await dbContext.SaveChangesAsync();
        TempData["SuccessMessage"] = $"تم حذف التقنية «{technology.Name}» بنجاح.";
        return RedirectToAction(nameof(Index));
    }

    private Task<Technology?> FindTechnologyAsync(int id) =>
        dbContext.Technologies.AsNoTracking()
            .Include(technology => technology.ProjectTechnologies)
            .SingleOrDefaultAsync(technology => technology.Id == id);

    private async Task ValidateUniqueNameAsync(string? name, int? excludedId = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return;
        }

        var normalizedName = name.Trim();
        var exists = await dbContext.Technologies.AnyAsync(
            technology => technology.Name == normalizedName
                && (!excludedId.HasValue || technology.Id != excludedId.Value));

        if (exists)
        {
            ModelState.AddModelError(nameof(Technology.Name), "يجب أن يكون اسم التقنية فريدًا.");
        }
    }

    private void ProcessSvgInput(Technology technology)
    {
        if (string.IsNullOrWhiteSpace(technology.IconSvg))
        {
            technology.IconSvg = null;
            return;
        }

        if (!SvgSanitizer.IsValidSvg(technology.IconSvg))
        {
            ModelState.AddModelError(nameof(Technology.IconSvg), "كود SVG غير صالح. يجب أن يضم وسوم <svg> و </svg> بشكل صحيح.");
            return;
        }

        var sanitized = SvgSanitizer.Sanitize(technology.IconSvg);
        if (string.IsNullOrWhiteSpace(sanitized))
        {
            ModelState.AddModelError(nameof(Technology.IconSvg), "يحتوي كود SVG على وسوم أو عناصر غير آمنة.");
            return;
        }

        technology.IconSvg = sanitized;
    }
}
