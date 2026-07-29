using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portflio.Data;
using Portflio.Data.Entities;

namespace Portflio.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public sealed class TestimonialsController(ApplicationDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var testimonials = await dbContext.Testimonials
            .AsNoTracking()
            .OrderBy(testimonial => testimonial.DisplayOrder)
            .ThenBy(testimonial => testimonial.Id)
            .ToListAsync();

        return View(testimonials);
    }

    public IActionResult Create() => View(new Testimonial());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("NameAr,NameEn,QuoteAr,QuoteEn,CompanyAr,CompanyEn,Rating,DisplayOrder,IsActive")]
        Testimonial testimonial)
    {
        if (!ModelState.IsValid)
        {
            return View(testimonial);
        }

        dbContext.Testimonials.Add(testimonial);
        await dbContext.SaveChangesAsync();

        TempData["SuccessMessage"] = $"تمت إضافة شهادة العميل «{testimonial.NameAr}» بنجاح.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var testimonial = await dbContext.Testimonials.FindAsync(id);
        return testimonial is null ? NotFound() : View(testimonial);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id,
        [Bind("Id,NameAr,NameEn,QuoteAr,QuoteEn,CompanyAr,CompanyEn,Rating,DisplayOrder,IsActive")]
        Testimonial testimonial)
    {
        if (id != testimonial.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(testimonial);
        }

        if (!await dbContext.Testimonials.AnyAsync(item => item.Id == id))
        {
            return NotFound();
        }

        dbContext.Testimonials.Update(testimonial);
        await dbContext.SaveChangesAsync();

        TempData["SuccessMessage"] = $"تم تحديث شهادة العميل «{testimonial.NameAr}» بنجاح.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var testimonial = await dbContext.Testimonials
            .AsNoTracking()
            .SingleOrDefaultAsync(item => item.Id == id);

        return testimonial is null ? NotFound() : View(testimonial);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var testimonial = await dbContext.Testimonials.FindAsync(id);
        if (testimonial is null)
        {
            return NotFound();
        }

        dbContext.Testimonials.Remove(testimonial);
        await dbContext.SaveChangesAsync();

        TempData["SuccessMessage"] = $"تم حذف شهادة العميل «{testimonial.NameAr}» بنجاح.";
        return RedirectToAction(nameof(Index));
    }
}
