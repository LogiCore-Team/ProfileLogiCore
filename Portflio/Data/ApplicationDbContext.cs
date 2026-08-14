using Microsoft.EntityFrameworkCore;
using Portflio.Data.Entities;

namespace Portflio.Data;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<ProjectMedia> ProjectMedia => Set<ProjectMedia>();
    public DbSet<ProjectFeature> ProjectFeatures => Set<ProjectFeature>();
    public DbSet<Technology> Technologies => Set<Technology>();
    public DbSet<ProjectTechnology> ProjectTechnologies => Set<ProjectTechnology>();
    public DbSet<TeamMember> TeamMembers => Set<TeamMember>();
    public DbSet<Service> Services => Set<Service>();
    public DbSet<StatItem> StatItems => Set<StatItem>();
    public DbSet<Testimonial> Testimonials => Set<Testimonial>();
    public DbSet<ContactMessage> ContactMessages => Set<ContactMessage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Project>(entity =>
        {
            entity.Property(project => project.TitleAr).HasMaxLength(200).IsRequired();
            entity.Property(project => project.TitleEn).HasMaxLength(200).IsRequired();
            entity.Property(project => project.ShortDescriptionAr).HasMaxLength(500).IsRequired();
            entity.Property(project => project.ShortDescriptionEn).HasMaxLength(500).IsRequired();
            entity.Property(project => project.FullDescriptionAr).HasMaxLength(4000).IsRequired();
            entity.Property(project => project.FullDescriptionEn).HasMaxLength(4000).IsRequired();
            entity.Property(project => project.ClientName).HasMaxLength(200).IsRequired();
            entity.Property(project => project.Category).HasMaxLength(100).IsRequired();
            entity.Property(project => project.CoverImageUrl).HasMaxLength(2048);
            entity.Property(project => project.LiveDemoUrl).HasMaxLength(2048);
            entity.Property(project => project.RepoUrl).HasMaxLength(2048);
            entity.Property(project => project.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasIndex(project => project.Category);
            entity.HasIndex(project => new { project.IsFeatured, project.CreatedAt });
        });

        modelBuilder.Entity<ProjectMedia>(entity =>
        {
            entity.Property(media => media.MediaUrl).HasMaxLength(2048).IsRequired();
            entity.Property(media => media.MediaType)
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();
            entity.HasIndex(media => new { media.ProjectId, media.DisplayOrder });

            entity.HasOne(media => media.Project)
                .WithMany(project => project.Media)
                .HasForeignKey(media => media.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ProjectFeature>(entity =>
        {
            entity.Property(feature => feature.FeatureTextAr).HasMaxLength(500).IsRequired();
            entity.Property(feature => feature.FeatureTextEn).HasMaxLength(500).IsRequired();
            entity.HasIndex(feature => new { feature.ProjectId, feature.DisplayOrder });

            entity.HasOne(feature => feature.Project)
                .WithMany(project => project.Features)
                .HasForeignKey(feature => feature.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Technology>(entity =>
        {
            entity.Property(technology => technology.Name).HasMaxLength(100).IsRequired();
            entity.Property(technology => technology.IconClass).HasMaxLength(200);
            entity.Property(technology => technology.ImageUrl).HasMaxLength(2048);
            entity.Property(technology => technology.IconSvg);
            entity.HasIndex(technology => technology.Name).IsUnique();
        });

        modelBuilder.Entity<ProjectTechnology>(entity =>
        {
            entity.HasKey(item => new { item.ProjectId, item.TechnologyId });

            entity.HasOne(item => item.Project)
                .WithMany(project => project.ProjectTechnologies)
                .HasForeignKey(item => item.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(item => item.Technology)
                .WithMany(technology => technology.ProjectTechnologies)
                .HasForeignKey(item => item.TechnologyId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<TeamMember>(entity =>
        {
            entity.Property(member => member.NameAr).HasMaxLength(200).IsRequired();
            entity.Property(member => member.NameEn).HasMaxLength(200).IsRequired();
            entity.Property(member => member.RoleAr).HasMaxLength(200).IsRequired();
            entity.Property(member => member.RoleEn).HasMaxLength(200).IsRequired();
            entity.Property(member => member.ProfileImageUrl).HasMaxLength(2048);
            entity.Property(member => member.SkillsCsv).HasMaxLength(1000);
            entity.Property(member => member.GitHubUrl).HasMaxLength(2048);
            entity.Property(member => member.LinkedInUrl).HasMaxLength(2048);
            entity.HasIndex(member => new { member.IsActive, member.DisplayOrder });
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.Property(service => service.TitleAr).HasMaxLength(200).IsRequired();
            entity.Property(service => service.TitleEn).HasMaxLength(200).IsRequired();
            entity.Property(service => service.DescriptionAr).HasMaxLength(1000).IsRequired();
            entity.Property(service => service.DescriptionEn).HasMaxLength(1000).IsRequired();
            entity.Property(service => service.IconClass).HasMaxLength(200);
            entity.HasIndex(service => new { service.IsActive, service.DisplayOrder });
        });

        modelBuilder.Entity<StatItem>(entity =>
        {
            entity.Property(stat => stat.Value).HasMaxLength(50).IsRequired();
            entity.Property(stat => stat.LabelAr).HasMaxLength(200).IsRequired();
            entity.Property(stat => stat.LabelEn).HasMaxLength(200).IsRequired();
            entity.HasIndex(stat => stat.DisplayOrder);
        });

        modelBuilder.Entity<Testimonial>(entity =>
        {
            entity.Property(testimonial => testimonial.QuoteAr).HasMaxLength(2000).IsRequired();
            entity.Property(testimonial => testimonial.QuoteEn).HasMaxLength(2000).IsRequired();
            entity.Property(testimonial => testimonial.NameAr).HasMaxLength(200).IsRequired();
            entity.Property(testimonial => testimonial.NameEn).HasMaxLength(200).IsRequired();
            entity.Property(testimonial => testimonial.CompanyAr).HasMaxLength(200).IsRequired();
            entity.Property(testimonial => testimonial.CompanyEn).HasMaxLength(200).IsRequired();
            entity.HasIndex(testimonial => new
            {
                testimonial.IsActive,
                testimonial.DisplayOrder
            });
        });

        modelBuilder.Entity<ContactMessage>(entity =>
        {
            entity.Property(message => message.Name).HasMaxLength(200).IsRequired();
            entity.Property(message => message.Email).HasMaxLength(320).IsRequired();
            entity.Property(message => message.Subject).HasMaxLength(300).IsRequired();
            entity.Property(message => message.Message).HasMaxLength(4000).IsRequired();
            entity.Property(message => message.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.HasIndex(message => new { message.IsRead, message.CreatedAt });
        });
    }
}
