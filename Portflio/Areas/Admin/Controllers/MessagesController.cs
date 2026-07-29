using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portflio.Data;

namespace Portflio.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public sealed class MessagesController(ApplicationDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var messages = await dbContext.ContactMessages
            .AsNoTracking()
            .OrderByDescending(m => m.CreatedAt)
            .ToListAsync();

        return View(messages);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> MarkAsRead(int id)
    {
        var message = await dbContext.ContactMessages.FindAsync(id);
        if (message != null)
        {
            message.IsRead = true;
            await dbContext.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var message = await dbContext.ContactMessages.FindAsync(id);
        if (message != null)
        {
            dbContext.ContactMessages.Remove(message);
            await dbContext.SaveChangesAsync();
            TempData["SuccessMessage"] = "تم حذف الرسالة بنجاح.";
        }
        return RedirectToAction(nameof(Index));
    }
}
