using System.ComponentModel.DataAnnotations;

namespace Portflio.Data.Entities;

public sealed class ContactMessage
{
    public int Id { get; set; }

    [Required, StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required, EmailAddress, StringLength(320)]
    public string Email { get; set; } = string.Empty;

    [Required, StringLength(300)]
    public string Subject { get; set; } = string.Empty;

    [Required, StringLength(4000)]
    public string Message { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public bool IsRead { get; set; }
}
