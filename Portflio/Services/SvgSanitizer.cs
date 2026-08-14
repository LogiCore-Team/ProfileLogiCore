using System.Text.RegularExpressions;

namespace Portflio.Services;

public static class SvgSanitizer
{
    private static readonly Regex ScriptTagRegex = new(@"<script[^>]*>[\s\S]*?</script\s*>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    private static readonly Regex IframeTagRegex = new(@"<iframe[^>]*>[\s\S]*?</iframe\s*>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    private static readonly Regex EventHandlerRegex = new(@"\son\w+\s*=\s*([""'][^""']*[""']|[^\s>]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    private static readonly Regex JavascriptUrlRegex = new(@"href\s*=\s*([""']\s*javascript:[^""']*[""']|javascript:[^\s>]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    public static bool IsValidSvg(string? svgContent)
    {
        if (string.IsNullOrWhiteSpace(svgContent))
        {
            return false;
        }

        var trimmed = svgContent.Trim();
        return trimmed.Contains("<svg", StringComparison.OrdinalIgnoreCase)
            && trimmed.Contains("</svg>", StringComparison.OrdinalIgnoreCase);
    }

    public static string? Sanitize(string? svgContent)
    {
        if (string.IsNullOrWhiteSpace(svgContent))
        {
            return null;
        }

        var sanitized = svgContent.Trim();
        sanitized = ScriptTagRegex.Replace(sanitized, string.Empty);
        sanitized = IframeTagRegex.Replace(sanitized, string.Empty);
        sanitized = EventHandlerRegex.Replace(sanitized, string.Empty);
        sanitized = JavascriptUrlRegex.Replace(sanitized, string.Empty);

        return IsValidSvg(sanitized) ? sanitized : null;
    }
}
