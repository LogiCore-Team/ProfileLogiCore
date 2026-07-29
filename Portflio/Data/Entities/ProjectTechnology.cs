namespace Portflio.Data.Entities;

public sealed class ProjectTechnology
{
    public int ProjectId { get; set; }
    public int TechnologyId { get; set; }

    public Project Project { get; set; } = null!;
    public Technology Technology { get; set; } = null!;
}
