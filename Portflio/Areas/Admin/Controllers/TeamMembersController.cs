using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portflio.Data;
using Portflio.Data.Entities;

namespace Portflio.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public sealed class TeamMembersController(ApplicationDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index() =>
        View(await dbContext.TeamMembers.AsNoTracking()
            .OrderBy(member => member.DisplayOrder)
            .ThenBy(member => member.NameEn)
            .ToListAsync());

    public async Task<IActionResult> Details(int id)
    {
        var member = await dbContext.TeamMembers.AsNoTracking()
            .SingleOrDefaultAsync(item => item.Id == id);
        return member is null ? NotFound() : View(member);
    }

    public IActionResult Create() => View(new TeamMember());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("NameAr,NameEn,RoleAr,RoleEn,ProfileImageUrl,SkillsCsv,GitHubUrl,LinkedInUrl,DisplayOrder,IsActive")]
        TeamMember member)
    {
        if (!ModelState.IsValid)
        {
            return View(member);
        }

        dbContext.TeamMembers.Add(member);
        await dbContext.SaveChangesAsync();
        TempData["SuccessMessage"] = $"تم إنشاء عضو الفريق «{member.NameAr}» بنجاح.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var member = await dbContext.TeamMembers.FindAsync(id);
        return member is null ? NotFound() : View(member);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id,
        [Bind("Id,NameAr,NameEn,RoleAr,RoleEn,ProfileImageUrl,SkillsCsv,GitHubUrl,LinkedInUrl,DisplayOrder,IsActive")]
        TeamMember member)
    {
        if (id != member.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(member);
        }

        if (!await dbContext.TeamMembers.AnyAsync(item => item.Id == id))
        {
            return NotFound();
        }

        dbContext.Update(member);
        await dbContext.SaveChangesAsync();
        TempData["SuccessMessage"] = $"تم تحديث عضو الفريق «{member.NameAr}» بنجاح.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var member = await dbContext.TeamMembers.AsNoTracking()
            .SingleOrDefaultAsync(item => item.Id == id);
        return member is null ? NotFound() : View(member);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var member = await dbContext.TeamMembers.FindAsync(id);
        if (member is null)
        {
            return NotFound();
        }

        dbContext.TeamMembers.Remove(member);
        await dbContext.SaveChangesAsync();
        TempData["SuccessMessage"] = $"تم حذف عضو الفريق «{member.NameAr}» بنجاح.";
        return RedirectToAction(nameof(Index));
    }
}
