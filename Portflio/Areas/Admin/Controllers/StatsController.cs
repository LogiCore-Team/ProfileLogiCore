using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portflio.Data;
using Portflio.Data.Entities;

namespace Portflio.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public sealed class StatsController(ApplicationDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index() =>
        View(await dbContext.StatItems.AsNoTracking()
            .OrderBy(stat => stat.DisplayOrder)
            .ThenBy(stat => stat.Id)
            .ToListAsync());

    public async Task<IActionResult> Details(int id)
    {
        var stat = await dbContext.StatItems.AsNoTracking()
            .SingleOrDefaultAsync(item => item.Id == id);
        return stat is null ? NotFound() : View(stat);
    }

    public IActionResult Create() => View(new StatItem { DisplayOrder = 1 });

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Value,LabelAr,LabelEn,DisplayOrder")] StatItem statItem)
    {
        if (!ModelState.IsValid)
        {
            return View(statItem);
        }

        dbContext.StatItems.Add(statItem);
        await dbContext.SaveChangesAsync();
        TempData["SuccessMessage"] = $"تم إنشاء الإحصائية «{statItem.Value} - {statItem.LabelAr}» بنجاح.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var stat = await dbContext.StatItems.FindAsync(id);
        return stat is null ? NotFound() : View(stat);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id,
        [Bind("Id,Value,LabelAr,LabelEn,DisplayOrder")] StatItem statItem)
    {
        if (id != statItem.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(statItem);
        }

        if (!await dbContext.StatItems.AnyAsync(item => item.Id == id))
        {
            return NotFound();
        }

        dbContext.Update(statItem);
        await dbContext.SaveChangesAsync();
        TempData["SuccessMessage"] = $"تم تحديث الإحصائية «{statItem.Value} - {statItem.LabelAr}» بنجاح.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var stat = await dbContext.StatItems.AsNoTracking()
            .SingleOrDefaultAsync(item => item.Id == id);
        return stat is null ? NotFound() : View(stat);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var stat = await dbContext.StatItems.FindAsync(id);
        if (stat is null)
        {
            return NotFound();
        }

        dbContext.StatItems.Remove(stat);
        await dbContext.SaveChangesAsync();
        TempData["SuccessMessage"] = $"تم حذف الإحصائية «{stat.Value} - {stat.LabelAr}» بنجاح.";
        return RedirectToAction(nameof(Index));
    }
}
