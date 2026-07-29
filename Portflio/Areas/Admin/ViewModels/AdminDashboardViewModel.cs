namespace Portflio.Areas.Admin.ViewModels;

public sealed record AdminDashboardViewModel(
    int Projects,
    int Services,
    int Technologies,
    int TeamMembers,
    int Stats,
    int Testimonials);
