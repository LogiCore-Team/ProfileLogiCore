using Portflio.ViewModels.Common;
using Portflio.ViewModels.Home;
using Portflio.ViewModels.Projects;

namespace Portflio.Services;

public sealed class MockPortfolioContentProvider : IPortfolioContentProvider
{
    private static readonly IReadOnlyList<FilterOptionViewModel> ProjectCategories =
    [
        new("web", L("Web", "ويب")),
        new("mobile", L("Mobile", "تطبيقات الجوال")),
        new("smart", L("AI / Smart Systems", "الذكاء والأنظمة الذكية")),
        new("enterprise", L("Enterprise", "حلول المؤسسات"))
    ];

    private static readonly IReadOnlyList<FilterOptionViewModel> TechnologyCategories =
    [
        new("backend", L("Backend", "الخلفية")),
        new("frontend", L("Frontend", "الواجهة")),
        new("aiData", L("AI / Data", "الذكاء والبيانات")),
        new("cloud", L("Cloud", "السحابة"))
    ];

    private static readonly IReadOnlyList<TechnologyViewModel> Technologies =
    [
        new("C#", "backend", L("Enterprise logic", "منطق مؤسسي")),
        new(".NET 8", "backend", L("APIs & services", "واجهات وخدمات")),
        new("Python", "aiData", L("AI & automation", "ذكاء وأتمتة")),
        new("JavaScript", "frontend", L("Interactive UI", "واجهات تفاعلية")),
        new("HTML5", "frontend", L("Semantic structure", "بنية دلالية")),
        new("CSS3", "frontend", L("Responsive systems", "تصميم متجاوب")),
        new("Azure", "cloud", L("Cloud delivery", "تسليم سحابي")),
        new("SQL Server", "backend", L("Reliable data", "بيانات موثوقة"))
    ];

    private static readonly IReadOnlyList<ServiceViewModel> Services =
    [
        new("WEB", L("Custom Web Applications", "تطبيقات ويب مخصصة"),
            L("Responsive portals, SaaS dashboards, and workflow tools designed for daily operational clarity.",
              "بوابات ولوحات SaaS وأدوات سير عمل متجاوبة مصممة لوضوح العمليات اليومية.")),
        new("APP", L("Cross-Platform Mobile Apps", "تطبيقات جوال متعددة المنصات"),
            L("Polished mobile experiences with fast workflows and dependable delivery across platforms.",
              "تجارب جوال مصقولة بمسارات سريعة وتسليم موثوق عبر المنصات.")),
        new("AI", L("Intelligent Systems & Automation", "الأنظمة الذكية والأتمتة"),
            L("Prediction, document intelligence, data processing, and Python-powered product automation.",
              "التنبؤ وذكاء المستندات ومعالجة البيانات وأتمتة المنتجات المدعومة بلغة Python.")),
        new(".NET", L("Enterprise Backend & Cloud", "الخلفيات المؤسسية والسحابة"),
            L("Secure .NET APIs, integrations, and cloud-ready services engineered for enterprise scale.",
              "واجهات .NET وتكاملات وخدمات سحابية آمنة مصممة للتوسع المؤسسي."))
    ];

    private static readonly IReadOnlyList<TeamMemberViewModel> TeamMembers =
    [
        new("AK", L("Amin Kareem", "أمين كريم"), L("Solution Architect", "مهندس حلول"),
            ["C#", ".NET", "Azure"], "https://github.com/logicore-dev", "https://linkedin.com/company/logicore-dev"),
        new("LY", L("Lina Youssef", "لينا يوسف"), L("Frontend & UX Engineer", "مهندسة واجهات وتجربة مستخدم"),
            ["JavaScript", "UX", "CSS3"], "https://github.com/logicore-dev", "https://linkedin.com/company/logicore-dev"),
        new("MS", L("Mazen Saad", "مازن سعد"), L("AI / Python Engineer", "مهندس ذكاء اصطناعي وPython"),
            ["Python", "Data", "Automation"], "https://github.com/logicore-dev", "https://linkedin.com/company/logicore-dev"),
        new("NR", L("Noura Rashid", "نورة راشد"), L("Mobile Delivery Lead", "قائدة تطوير الجوال"),
            ["Mobile", "QA", "Product"], "https://github.com/logicore-dev", "https://linkedin.com/company/logicore-dev")
    ];

    private static readonly IReadOnlyList<TestimonialViewModel> Testimonials =
    [
        new(
            L("LOGICORE translated our complex approval process into a calm, fast platform our operations team enjoys using.",
              "حوّلت LOGICORE عملية الموافقات المعقدة لدينا إلى منصة هادئة وسريعة يستمتع فريق العمليات باستخدامها."),
            L("Sara Al-Naim", "سارة النعيم"),
            L("Northline Logistics", "نورث لاين للخدمات اللوجستية"),
            5),
        new(
            L("Their architecture choices were thoughtful from day one. We shipped quickly without creating future maintenance debt.",
              "كانت اختياراتهم المعمارية مدروسة منذ اليوم الأول. أطلقنا بسرعة من دون خلق عبء صيانة مستقبلي."),
            L("Omar Haddad", "عمر حداد"),
            L("Crescent Cloud", "كريسنت كلاود"),
            5),
        new(
            L("The team blended UX, backend reliability, and automation in a way that made our product feel immediately mature.",
              "جمع الفريق بين تجربة المستخدم وموثوقية الخلفية والأتمتة بطريقة جعلت منتجنا يبدو ناضجاً منذ البداية."),
            L("Maya Rahman", "مايا رحمن"),
            L("BrightOps", "برايت أوبس"),
            5)
    ];

    private static readonly IReadOnlyList<ProjectSeed> Projects =
    [
        new(
            1, "enterprise", L("Atlas Operations Portal", "بوابة أطلس للعمليات"),
            L("A role-aware command center for field teams, approvals, and live operational performance.",
              "مركز قيادة واعٍ بالصلاحيات لفرق الميدان والموافقات ومؤشرات الأداء المباشرة."),
            "Northline Logistics", L("7 months", "7 أشهر"), "2026", "atlas",
            "https://example.com/logicore-atlas", "https://github.com/logicore-dev/atlas-portal",
            L("Field operations were spread across spreadsheets, chat threads, and disconnected approval tools. Managers lacked a dependable view of workloads, delays, and accountability.",
              "كانت العمليات الميدانية موزعة بين جداول البيانات والمحادثات وأدوات موافقة منفصلة، ولم يمتلك المديرون رؤية موثوقة للأحمال والتأخيرات والمسؤوليات."),
            L("LOGICORE delivered a secure operations portal with role-based workspaces, configurable approvals, live KPIs, and an integration layer for existing systems.",
              "قدمت LOGICORE بوابة عمليات آمنة بمساحات عمل حسب الأدوار وموافقات قابلة للتهيئة ومؤشرات مباشرة وطبقة تكامل مع الأنظمة القائمة."),
            ["Role-aware workspaces", "Live operations dashboard", "Configurable approvals", "Audit-ready activity history"],
            ["مساحات حسب الصلاحيات", "لوحة عمليات مباشرة", "موافقات قابلة للتهيئة", "سجل نشاط جاهز للتدقيق"],
            ["C#", ".NET 8", "JavaScript", "SQL Server", "Azure"]),
        new(
            2, "mobile", L("Pulse Mobile CRM", "تطبيق بالس لإدارة العملاء"),
            L("An offline-first sales companion built for fast customer activity tracking in the field.",
              "رفيق مبيعات يعمل دون اتصال لتتبع نشاط العملاء بسرعة في الميدان."),
            "Crescent Retail", L("5 months", "5 أشهر"), "2026", "pulse",
            "https://example.com/logicore-pulse", "https://github.com/logicore-dev/pulse-mobile",
            L("Sales representatives lost context when connectivity dropped, and customer updates often arrived too late for managers to act on them.",
              "كان مندوبو المبيعات يفقدون السياق عند انقطاع الاتصال، وغالباً ما تصل تحديثات العملاء متأخرة إلى المديرين."),
            L("We designed an offline-first mobile workflow with conflict-safe synchronization, compact customer timelines, and prioritized daily actions.",
              "صممنا مسار جوال يعمل دون اتصال مع مزامنة آمنة من التعارض وخطوط زمنية مختصرة للعملاء وأولويات يومية واضحة."),
            ["Offline customer records", "Background synchronization", "Fast activity capture", "Daily sales priorities"],
            ["سجلات عملاء دون اتصال", "مزامنة في الخلفية", "تسجيل سريع للنشاط", "أولويات مبيعات يومية"],
            ["JavaScript", ".NET 8", "CSS3", "SQL Server"]),
        new(
            3, "smart", L("Nexus AI Routing Engine", "محرك نيكسس للتوجيه الذكي"),
            L("An intelligent request-routing layer that classifies demand and recommends the next best action.",
              "طبقة ذكية لتوجيه الطلبات تصنف الاحتياج وتقترح أفضل إجراء تالٍ."),
            "BrightOps", L("4 months", "4 أشهر"), "2025", "nexus",
            "https://example.com/logicore-nexus", "https://github.com/logicore-dev/nexus-ai",
            L("Thousands of incoming requests were manually categorized, creating inconsistent priorities and long response queues.",
              "كانت آلاف الطلبات الواردة تصنف يدوياً، مما أدى إلى أولويات غير متسقة وطوابير استجابة طويلة."),
            L("LOGICORE created a Python classification service with confidence scoring, human review paths, and a .NET integration API.",
              "أنشأت LOGICORE خدمة تصنيف بلغة Python مع درجات ثقة ومسارات مراجعة بشرية وواجهة تكامل عبر .NET."),
            ["Intent classification", "Priority scoring", "Human review queue", "Explainable recommendations"],
            ["تصنيف النوايا", "تقييم الأولوية", "قائمة مراجعة بشرية", "توصيات قابلة للتفسير"],
            ["Python", ".NET 8", "Azure", "SQL Server"]),
        new(
            4, "web", L("Forge SaaS Dashboard", "لوحة فورج السحابية"),
            L("A high-density analytics workspace with clear insights, account controls, and responsive layouts.",
              "مساحة تحليلات كثيفة وواضحة مع تحكم بالحسابات وتخطيطات متجاوبة."),
            "Forge Metrics", L("6 months", "6 أشهر"), "2025", "forge",
            "https://example.com/logicore-forge", "https://github.com/logicore-dev/forge-dashboard",
            L("Customers had powerful data but no efficient way to scan performance, compare accounts, or understand anomalies across devices.",
              "امتلك العملاء بيانات قوية من دون طريقة فعالة لمسح الأداء ومقارنة الحسابات وفهم الحالات الشاذة عبر الأجهزة."),
            L("We built a responsive analytics system with composable widgets, saved views, accessible charts, and clear account controls.",
              "بنينا نظام تحليلات متجاوباً بعناصر قابلة للتركيب وعروض محفوظة ورسوم يسهل الوصول إليها وتحكم واضح بالحسابات."),
            ["Composable dashboards", "Saved analytical views", "Accessible data states", "Responsive account controls"],
            ["لوحات قابلة للتركيب", "عروض تحليلية محفوظة", "حالات بيانات سهلة الوصول", "تحكم متجاوب بالحسابات"],
            ["JavaScript", "HTML5", "CSS3", ".NET 8"]),
        new(
            5, "smart", L("Sentinel Quality Monitor", "مراقب سنتينل للجودة"),
            L("An intelligent monitoring system that surfaces process drift before it becomes operational loss.",
              "نظام مراقبة ذكي يكشف انحراف العمليات قبل أن يتحول إلى خسارة تشغيلية."),
            "Apex Manufacturing", L("8 months", "8 أشهر"), "2025", "sentinel",
            "https://example.com/logicore-sentinel", "https://github.com/logicore-dev/sentinel-monitor",
            L("Quality teams reviewed large volumes of production data after the fact, making early intervention difficult and expensive.",
              "كانت فرق الجودة تراجع كميات كبيرة من بيانات الإنتاج بعد وقوع المشكلة، مما جعل التدخل المبكر صعباً ومكلفاً."),
            L("Sentinel combines streaming rules, anomaly scoring, alert triage, and investigation timelines in one operational interface.",
              "يجمع سنتينل قواعد التدفق وتقييم الحالات الشاذة وفرز التنبيهات وخطوط التحقيق الزمنية في واجهة تشغيلية واحدة."),
            ["Drift detection", "Risk-based alerts", "Investigation timelines", "Quality trend reporting"],
            ["اكتشاف الانحراف", "تنبيهات حسب المخاطر", "خطوط زمنية للتحقيق", "تقارير اتجاهات الجودة"],
            ["Python", "C#", ".NET 8", "Azure"]),
        new(
            6, "mobile", L("Meridian Service App", "تطبيق ميريديان للخدمات"),
            L("A field-service application for tickets, inspections, evidence, and synchronized status updates.",
              "تطبيق خدمة ميدانية للتذاكر والفحوصات والأدلة وتحديثات الحالة المتزامنة."),
            "Meridian Facilities", L("5 months", "5 أشهر"), "2025", "meridian",
            "https://example.com/logicore-meridian", "https://github.com/logicore-dev/meridian-service",
            L("Technicians relied on paper notes and delayed calls, while dispatch teams lacked accurate progress and completion evidence.",
              "اعتمد الفنيون على الملاحظات الورقية والاتصالات المتأخرة، بينما افتقرت فرق التوجيه إلى تقدم دقيق وأدلة إنجاز."),
            L("We delivered guided inspections, media evidence capture, offline ticket updates, and live dispatch synchronization.",
              "قدمنا فحوصات موجهة والتقاط أدلة وسائط وتحديث تذاكر دون اتصال ومزامنة مباشرة مع التوجيه."),
            ["Guided inspections", "Evidence capture", "Offline ticket updates", "Live dispatch status"],
            ["فحوصات موجهة", "التقاط الأدلة", "تحديثات دون اتصال", "حالة توجيه مباشرة"],
            ["JavaScript", ".NET 8", "CSS3", "Azure"]),
        new(
            7, "web", L("Horizon Customer Hub", "مركز هورايزن للعملاء"),
            L("A self-service web experience that turns complex account tasks into clear guided journeys.",
              "تجربة ويب للخدمة الذاتية تحول مهام الحساب المعقدة إلى رحلات واضحة وموجهة."),
            "Horizon Energy", L("6 months", "6 أشهر"), "2026", "horizon",
            "https://example.com/logicore-horizon", "https://github.com/logicore-dev/horizon-hub",
            L("Support teams handled routine account requests manually because customers could not complete multi-step tasks with confidence.",
              "كانت فرق الدعم تعالج طلبات الحساب الروتينية يدوياً لأن العملاء لم يتمكنوا من إكمال المهام متعددة الخطوات بثقة."),
            L("The new hub combines guided service flows, document status, contextual help, and a unified account timeline.",
              "يجمع المركز الجديد مسارات خدمة موجهة وحالة المستندات والمساعدة السياقية وخطاً زمنياً موحداً للحساب."),
            ["Guided service journeys", "Document tracking", "Contextual assistance", "Unified account timeline"],
            ["رحلات خدمة موجهة", "تتبع المستندات", "مساعدة سياقية", "خط زمني موحد للحساب"],
            ["JavaScript", "HTML5", "CSS3", ".NET 8"]),
        new(
            8, "enterprise", L("CoreLedger Integration Suite", "حزمة كور ليدجر للتكامل"),
            L("A dependable integration platform connecting finance, operations, and partner systems.",
              "منصة تكامل موثوقة تربط أنظمة المالية والعمليات والشركاء."),
            "Summit Holdings", L("9 months", "9 أشهر"), "2024", "coreledger",
            "https://example.com/logicore-coreledger", "https://github.com/logicore-dev/coreledger",
            L("Critical transactions moved through brittle point-to-point integrations with limited traceability and difficult recovery.",
              "كانت المعاملات الحرجة تمر عبر تكاملات مباشرة هشة مع تتبع محدود واستعادة صعبة."),
            L("CoreLedger introduced versioned APIs, resilient message processing, traceable workflows, and operational recovery tools.",
              "قدم كور ليدجر واجهات بإصدارات ومعالجة رسائل مرنة ومسارات قابلة للتتبع وأدوات استعادة تشغيلية."),
            ["Versioned partner APIs", "Resilient message handling", "End-to-end traceability", "Operational replay tools"],
            ["واجهات شركاء بإصدارات", "معالجة رسائل مرنة", "تتبع شامل", "أدوات إعادة تشغيل العمليات"],
            ["C#", ".NET 8", "SQL Server", "Azure"])
    ];

    public HomePageViewModel GetHomePage()
    {
        var featured = Projects.Take(6).Select(ToCard).ToArray();

        return new HomePageViewModel(
            Services,
            Technologies,
            TechnologyCategories,
            featured,
            ProjectCategories,
            TeamMembers,
            Testimonials,
            [
                new("24h", L("Average response time", "متوسط زمن الاستجابة")),
                new("92", L("Projects delivered", "مشروعًا منجزًا")),
                new("96%", L("Client satisfaction", "رضا العملاء")),
                new("+48", L("Active partnerships", "شراكة نشطة"))
            ]);
    }

    public ProjectsPageViewModel GetProjects(string? category = null)
    {
        var normalizedCategory = ProjectCategories.Any(item =>
            string.Equals(item.Key, category, StringComparison.OrdinalIgnoreCase))
                ? category!.ToLowerInvariant()
                : "all";

        var projects = Projects.Select(ToCard).ToArray();

        return new ProjectsPageViewModel(ProjectCategories, projects, normalizedCategory);
    }

    public ProjectDetailsViewModel? GetProject(int id)
    {
        var project = Projects.FirstOrDefault(item => item.Id == id);
        if (project is null)
        {
            return null;
        }

        var category = ProjectCategories.First(item => item.Key == project.CategoryKey).Label;
        var features = project.FeatureTitlesEnglish
            .Select((title, index) => new ProjectFeatureViewModel(
                (index + 1).ToString("00"),
                L(title, project.FeatureTitlesArabic[index]),
                FeatureDescription(project.CategoryKey, index)))
            .ToArray();

        var media = new[]
        {
            new ProjectMediaViewModel($"{project.VisualVariant}-overview",
                L("Command overview", "نظرة القيادة"),
                L("A focused overview of the most important work and live signals.",
                  "نظرة مركزة على أهم الأعمال والإشارات المباشرة.")),
            new ProjectMediaViewModel($"{project.VisualVariant}-workflow",
                L("Guided workflow", "مسار عمل موجه"),
                L("A clear, step-based experience for completing high-value tasks.",
                  "تجربة واضحة قائمة على الخطوات لإكمال المهام عالية القيمة.")),
            new ProjectMediaViewModel($"{project.VisualVariant}-insights",
                L("Operational insights", "رؤى تشغيلية"),
                L("Responsive insight panels designed for confident decisions.",
                  "لوحات رؤى متجاوبة مصممة لاتخاذ قرارات واثقة."))
        };

        return new ProjectDetailsViewModel(
            project.Id,
            project.CategoryKey,
            category,
            project.Title,
            project.Summary,
            project.Client,
            project.Duration,
            project.Year,
            project.LiveDemoUrl,
            project.RepositoryUrl,
            media,
            project.Problem,
            project.Solution,
            features,
            Technologies.Where(item => project.TechnologyNames.Contains(item.Name)).ToArray());
    }

    private static ProjectCardViewModel ToCard(ProjectSeed project)
    {
        var category = ProjectCategories.First(item => item.Key == project.CategoryKey).Label;
        return new ProjectCardViewModel(
            project.Id,
            project.CategoryKey,
            category,
            project.Title,
            project.Summary,
            project.Client,
            project.Year,
            project.VisualVariant,
            project.TechnologyNames);
    }

    private static LocalizedTextViewModel FeatureDescription(string category, int index)
    {
        var english = category switch
        {
            "mobile" => "Designed for fast, dependable use in real field conditions.",
            "smart" => "Built with transparent signals, review paths, and measurable outcomes.",
            "enterprise" => "Engineered for security, traceability, and dependable operational scale.",
            _ => "Shaped around clarity, accessibility, and responsive performance."
        };

        var arabic = category switch
        {
            "mobile" => "مصممة للاستخدام السريع والموثوق في ظروف العمل الميدانية.",
            "smart" => "مبنية بإشارات واضحة ومسارات مراجعة ونتائج قابلة للقياس.",
            "enterprise" => "مصممة للأمان والتتبع والتوسع التشغيلي الموثوق.",
            _ => "مصممة حول الوضوح وسهولة الوصول والأداء المتجاوب."
        };

        return L(english, arabic);
    }

    private static LocalizedTextViewModel L(string english, string arabic) => new(english, arabic);

    private sealed record ProjectSeed(
        int Id,
        string CategoryKey,
        LocalizedTextViewModel Title,
        LocalizedTextViewModel Summary,
        string Client,
        LocalizedTextViewModel Duration,
        string Year,
        string VisualVariant,
        string LiveDemoUrl,
        string RepositoryUrl,
        LocalizedTextViewModel Problem,
        LocalizedTextViewModel Solution,
        IReadOnlyList<string> FeatureTitlesEnglish,
        IReadOnlyList<string> FeatureTitlesArabic,
        IReadOnlyList<string> TechnologyNames);
}
