using Portflio.ViewModels.Common;

namespace Portflio.ViewModels.Home;

public sealed record TestimonialViewModel(
    LocalizedTextViewModel Quote,
    LocalizedTextViewModel Name,
    LocalizedTextViewModel Company,
    int Rating);
