(() => {
  "use strict";

  const translations = {
    en: {
      skip: "Skip to content",
      navLabel: "Primary navigation",
      menuOpen: "Open navigation menu",
      controlsLabel: "Site controls",
      themeToggle: "Toggle light and dark mode",
      languageLabel: "Language",
      navHome: "Home",
      navAbout: "About",
      navServices: "Services",
      navTech: "Tech Stack",
      navPortfolio: "Portfolio",
      navTeam: "Team",
      navTestimonials: "Testimonials",
      navContact: "Contact",
      heroEyebrow: "Software Engineering Team",
      heroTitle: 'Intelligence-driven <span class="text-gradient-electric">software, engineered</span> with mastery<span class="gold-dot-accent">.</span>',
      heroLead: "Engineering smart systems, modern web products, mobile experiences, and enterprise platforms that scale cleanly.",
      typingPrefix: "We build",
      heroCtaWork: "Explore Our Work",
      heroCtaContact: "Contact Us",
      heroVisualLabel: "Abstract LOGICORE technology interface",
      heroChip: "Smart Core",
      heroSignalA: "Reliable delivery",
      heroSignalB: "Fast interfaces",
      heroFeature1: "Custom Solutions",
      heroFeature2: "Integrated Security",
      heroFeature3: "High Performance",
      heroFeature4: "Scalability",
      aboutEyebrow: "About LOGICORE",
      aboutTitle: "We turn complex business logic into elegant digital products.",
      aboutText: "Our team blends architecture, product thinking, clean interfaces, and reliable engineering to ship systems that teams trust every day.",
      visionTitle: "Vision",
      visionText: "Make intelligent software practical, maintainable, and valuable for ambitious teams.",
      missionTitle: "Mission",
      missionText: "Deliver polished applications backed by strong architecture and measurable quality.",
      craftTitle: "Craft",
      craftText: "Write readable code, design humane workflows, and document decisions that matter.",
      statProjects: "Projects Delivered",
      statSatisfaction: "Client Satisfaction",
      statQuality: "Quality Score",
      statResponse: "Average Response",
      servicesEyebrow: "Services",
      servicesTitle: "Engineering services for modern digital teams.",
      servicesIntro: "From product interfaces to cloud-backed enterprise systems, LOGICORE builds the pieces that keep organizations moving.",
      techEyebrow: "Technology Stack",
      techTitle: "A sharp stack for reliable products.",
      techIntro: "Filter the tools our team uses across backend, frontend, intelligent systems, and cloud delivery.",
      portfolioEyebrow: "Portfolio",
      portfolioTitle: "Selected work shaped for speed, clarity, and scale.",
      portfolioIntro: "Explore LOGICORE project work across web, mobile, smart systems, and enterprise platforms.",
      allProjects: "View all projects",
      teamEyebrow: "Team",
      teamTitle: "Senior builders with product instincts.",
      teamIntro: "A compact team covering architecture, experience design, backend systems, mobile delivery, and intelligent automation.",
      testimonialsEyebrow: "Client Success",
      testimonialsTitle: "Teams choose LOGICORE when software has to work beautifully.",
      noTestimonialsTitle: "No Testimonials Yet",
      noTestimonials: "Client testimonials will appear here once added from the admin panel.",
      prevTestimonial: "Previous testimonial",
      nextTestimonial: "Next testimonial",
      testimonialDots: "Testimonial slides",
      contactEyebrow: "Contact",
      contactTitle: "Tell us what you want to build.",
      contactIntro: "Share your idea, platform, or business workflow. LOGICORE will help shape the path from concept to production.",
      contactEmailTitle: "Email",
      contactLocationTitle: "Location",
      contactLocation: "Remote-first, serving global teams",
      contactResponseTitle: "Response Time",
      contactResponse: "Usually within one business day",
      formName: "Name",
      formNamePlaceholder: "Your full name",
      formEmail: "Email",
      formEmailPlaceholder: "you@example.com",
      formSubject: "Subject",
      formSubjectPlaceholder: "Project type or goal",
      formMessage: "Message",
      formMessagePlaceholder: "Tell us about your idea, timeline, and what success looks like.",
      formSubmit: "Send Message",
      footerTagline: "Built with logic & code by LOGICORE.",
      footerLinksLabel: "Footer quick links",
      socialLabel: "Social media",
      footerRights: "All rights reserved.",
      backToTop: "Back to Top",
      projectDemo: "Live Demo",
      projectGithub: "Repository",
      viewProject: "View Project",
      all: "All",
      noProjectsTitle: "Nothing here yet.",
      noProjects: "No projects match this filter.",
      nameError: "Please enter your name.",
      emailError: "Please enter a valid email address.",
      subjectError: "Please enter a subject.",
      messageError: "Please enter a message of at least 20 characters.",
      formSending: "Sending your message...",
      formSuccess: "Thanks. Your message is ready for LOGICORE to review.",
      formError: "We could not send your message. Please try again.",
      projectsBreadcrumb: "Projects",
      projectsPageTitle: "Digital products built for real operational momentum.",
      projectsPageIntro: "Explore the systems LOGICORE has shaped across customer experiences, field operations, intelligent automation, and enterprise platforms.",
      projectsCollection: "Project Collection",
      projectsGalleryTitle: "Find the work most relevant to your next build.",
      projectsShown: "projects shown",
      projectCtaEyebrow: "Have a complex idea?",
      projectCtaTitle: "Let’s turn it into a system people trust.",
      projectClient: "Client",
      projectDuration: "Duration",
      projectDelivered: "Delivered",
      projectPreviewEyebrow: "Interface Preview",
      projectPreviewTitle: "A closer look at the product experience.",
      previousImage: "Previous image",
      nextImage: "Next image",
      problemEyebrow: "The Challenge",
      problemTitle: "Problem Statement",
      solutionEyebrow: "The Response",
      solutionTitle: "Delivered Solution",
      featuresEyebrow: "Core Capabilities",
      featuresTitle: "Key features designed around the work.",
      technologyUsedEyebrow: "Technology Used",
      technologyUsedTitle: "A dependable stack behind the experience.",
      exploreMoreEyebrow: "Explore More",
      exploreMoreTitle: "See how LOGICORE approaches other product challenges.",
      backToProjects: "Back to all projects"
    },
    ar: {
      skip: "تخطي إلى المحتوى",
      navLabel: "التنقل الرئيسي",
      menuOpen: "فتح قائمة التنقل",
      controlsLabel: "إعدادات الموقع",
      themeToggle: "تبديل الوضع الفاتح والداكن",
      languageLabel: "اللغة",
      navHome: "الرئيسية",
      navAbout: "من نحن",
      navServices: "الخدمات",
      navTech: "التقنيات",
      navPortfolio: "الأعمال",
      navTeam: "الفريق",
      navTestimonials: "آراء العملاء",
      navContact: "تواصل",
      heroEyebrow: "فريق هندسة برمجيات",
      heroTitle: 'برمجيات ذكية <span class="text-gradient-electric">مصممة بإتقان</span> هندسي<span class="gold-dot-accent">.</span>',
      heroLead: "تصميم أنظمة ذكية ومنتجات ويب حديثة وتجارب جوال ومنصات مؤسسية قابلة للتوسع بثبات.",
      typingPrefix: "نطوّر",
      heroCtaWork: "استكشف أعمالنا",
      heroCtaContact: "تواصل معنا",
      heroVisualLabel: "واجهة تقنية تجريدية لفريق LOGICORE",
      heroChip: "النواة الذكية",
      heroSignalA: "تسليم موثوق",
      heroSignalB: "واجهات سريعة",
      heroFeature1: "حلول مخصصة",
      heroFeature2: "أمان متكامل",
      heroFeature3: "أداء عالي",
      heroFeature4: "قابلية للتوسع",
      aboutEyebrow: "عن LOGICORE",
      aboutTitle: "نحوّل منطق الأعمال المعقد إلى منتجات رقمية أنيقة.",
      aboutText: "يمزج فريقنا بين الهندسة المعمارية والتفكير المنتج والواجهات النظيفة والتنفيذ الموثوق لإطلاق أنظمة تعتمد عليها الفرق يومياً.",
      visionTitle: "الرؤية",
      visionText: "جعل البرمجيات الذكية عملية وقابلة للصيانة وذات قيمة للفرق الطموحة.",
      missionTitle: "الرسالة",
      missionText: "تسليم تطبيقات مصقولة مدعومة ببنية قوية وجودة قابلة للقياس.",
      craftTitle: "الحرفة",
      craftText: "نكتب كوداً واضحاً ونصمم تجارب إنسانية ونوثق القرارات المهمة.",
      statProjects: "مشروعاً منجزاً",
      statSatisfaction: "رضا العملاء",
      statQuality: "مؤشر الجودة",
      statResponse: "متوسط الاستجابة",
      servicesEyebrow: "الخدمات",
      servicesTitle: "خدمات هندسية للفرق الرقمية الحديثة.",
      servicesIntro: "من واجهات المنتجات إلى الأنظمة المؤسسية السحابية، تبني LOGICORE المكونات التي تحافظ على حركة المؤسسات.",
      techEyebrow: "التقنيات",
      techTitle: "مجموعة تقنية دقيقة لمنتجات موثوقة.",
      techIntro: "صفّ أدوات الفريق في الخلفية والواجهة والأنظمة الذكية والتسليم السحابي.",
      portfolioEyebrow: "الأعمال",
      portfolioTitle: "أعمال مختارة مصممة للسرعة والوضوح والتوسع.",
      portfolioIntro: "استكشف أعمال LOGICORE في الويب والجوال والأنظمة الذكية والمنصات المؤسسية.",
      allProjects: "عرض جميع المشاريع",
      teamEyebrow: "الفريق",
      teamTitle: "خبراء بناء برمجيات بحس منتج.",
      teamIntro: "فريق صغير يغطي البنية وتصميم التجربة وأنظمة الخلفية وتطبيقات الجوال والأتمتة الذكية.",
      testimonialsEyebrow: "نجاح العملاء",
      testimonialsTitle: "تختار الفرق LOGICORE عندما يجب أن تعمل البرمجيات بجمال وثبات.",
      noTestimonialsTitle: "لا تتوفر شهادات حالياً",
      noTestimonials: "ستظهر شهادات وآراء العملاء هنا فور إضافتها من لوحة الإدارة.",
      prevTestimonial: "الرأي السابق",
      nextTestimonial: "الرأي التالي",
      testimonialDots: "شرائح آراء العملاء",
      contactEyebrow: "تواصل",
      contactTitle: "أخبرنا بما تريد بناءه.",
      contactIntro: "شارك فكرتك أو منصتك أو سير عملك. ستساعدك LOGICORE في رسم الطريق من الفكرة إلى الإنتاج.",
      contactEmailTitle: "البريد",
      contactLocationTitle: "الموقع",
      contactLocation: "فريق مرن يخدم فرقاً عالمية",
      contactResponseTitle: "وقت الاستجابة",
      contactResponse: "عادة خلال يوم عمل واحد",
      formName: "الاسم",
      formNamePlaceholder: "اسمك الكامل",
      formEmail: "البريد الإلكتروني",
      formEmailPlaceholder: "you@example.com",
      formSubject: "الموضوع",
      formSubjectPlaceholder: "نوع المشروع أو الهدف",
      formMessage: "الرسالة",
      formMessagePlaceholder: "أخبرنا عن فكرتك والجدول الزمني وشكل النجاح المطلوب.",
      formSubmit: "إرسال الرسالة",
      footerTagline: "بُني بالمنطق والكود من LOGICORE.",
      footerLinksLabel: "روابط سريعة في التذييل",
      socialLabel: "وسائل التواصل",
      footerRights: "جميع الحقوق محفوظة.",
      backToTop: "العودة للأعلى",
      projectDemo: "عرض مباشر",
      projectGithub: "المستودع",
      viewProject: "عرض المشروع",
      all: "الكل",
      noProjectsTitle: "لا توجد نتائج حالياً.",
      noProjects: "لا توجد مشاريع مطابقة لهذا التصنيف.",
      nameError: "يرجى إدخال الاسم.",
      emailError: "يرجى إدخال بريد إلكتروني صحيح.",
      subjectError: "يرجى إدخال الموضوع.",
      messageError: "يرجى إدخال رسالة لا تقل عن 20 حرفاً.",
      formSending: "جارٍ إرسال رسالتك...",
      formSuccess: "شكراً لك. رسالتك جاهزة لمراجعة LOGICORE.",
      formError: "تعذر إرسال رسالتك. يرجى المحاولة مرة أخرى.",
      projectsBreadcrumb: "المشاريع",
      projectsPageTitle: "منتجات رقمية صُممت لدفع العمل الحقيقي إلى الأمام.",
      projectsPageIntro: "استكشف الأنظمة التي صممتها LOGICORE لتجارب العملاء والعمليات الميدانية والأتمتة الذكية والمنصات المؤسسية.",
      projectsCollection: "مجموعة المشاريع",
      projectsGalleryTitle: "اعثر على العمل الأقرب إلى مشروعك القادم.",
      projectsShown: "مشاريع معروضة",
      projectCtaEyebrow: "لديك فكرة معقدة؟",
      projectCtaTitle: "لنحولها إلى نظام يثق به الناس.",
      projectClient: "العميل",
      projectDuration: "المدة",
      projectDelivered: "تاريخ التسليم",
      projectPreviewEyebrow: "معاينة الواجهة",
      projectPreviewTitle: "نظرة أقرب إلى تجربة المنتج.",
      previousImage: "الصورة السابقة",
      nextImage: "الصورة التالية",
      problemEyebrow: "التحدي",
      problemTitle: "وصف المشكلة",
      solutionEyebrow: "الاستجابة",
      solutionTitle: "الحل المقدم",
      featuresEyebrow: "القدرات الأساسية",
      featuresTitle: "ميزات رئيسية مصممة حول العمل.",
      technologyUsedEyebrow: "التقنيات المستخدمة",
      technologyUsedTitle: "مجموعة تقنية موثوقة خلف التجربة.",
      exploreMoreEyebrow: "استكشف المزيد",
      exploreMoreTitle: "شاهد كيف تتعامل LOGICORE مع تحديات المنتجات الأخرى.",
      backToProjects: "العودة إلى جميع المشاريع"
    }
  };

  const typingWords = {
    en: ["Smart Systems", "Web Apps", "Mobile Apps", "Enterprise Platforms"],
    ar: ["أنظمة ذكية", "تطبيقات ويب", "تطبيقات جوال", "منصات مؤسسية"]
  };

  const state = {
    lang: localStorage.getItem("logicore-lang") || "en",
    theme: localStorage.getItem("logicore-theme") || "dark",
    typingWordIndex: 0,
    typingCharIndex: 0,
    typingDeleting: false,
    typingTimer: null
  };

  const $ = (selector, root = document) => root.querySelector(selector);
  const $$ = (selector, root = document) => [...root.querySelectorAll(selector)];
  const t = (key) => translations[state.lang]?.[key] || translations.en[key] || key;

  function applyTheme() {
    document.documentElement.dataset.theme = state.theme;
    localStorage.setItem("logicore-theme", state.theme);
    const metaTheme = $('meta[name="theme-color"]');
    if (metaTheme) {
      metaTheme.content = state.theme === "dark" ? "#0F172A" : "#F5F0E6";
    }
  }

  function applyLanguage() {
    document.documentElement.lang = state.lang;
    document.documentElement.dir = state.lang === "ar" ? "rtl" : "ltr";
    localStorage.setItem("logicore-lang", state.lang);

    $$("[data-i18n]").forEach((node) => {
      node.textContent = t(node.dataset.i18n);
    });

    $$("[data-i18n-html]").forEach((node) => {
      node.innerHTML = t(node.dataset.i18nHtml);
    });

    $$("[data-i18n-placeholder]").forEach((node) => {
      node.placeholder = t(node.dataset.i18nPlaceholder);
    });

    $$("[data-i18n-aria]").forEach((node) => {
      node.setAttribute("aria-label", t(node.dataset.i18nAria));
    });

    $$("[data-localized]").forEach((node) => {
      node.textContent = state.lang === "ar" ? node.dataset.ar : node.dataset.en;
    });

    $$("[data-localized-aria]").forEach((node) => {
      node.setAttribute("aria-label", state.lang === "ar" ? node.dataset.ar : node.dataset.en);
    });

    $$("[data-lang]").forEach((button) => {
      const isActive = button.dataset.lang === state.lang;
      button.classList.toggle("active", isActive);
      button.setAttribute("aria-pressed", String(isActive));
    });
  }

  function initPreferences() {
    const themeToggle = $("[data-theme-toggle]");
    if (themeToggle) {
      themeToggle.addEventListener("click", () => {
        state.theme = state.theme === "dark" ? "light" : "dark";
        applyTheme();
      });
    }

    $$("[data-lang]").forEach((button) => {
      button.addEventListener("click", () => {
        state.lang = button.dataset.lang;
        applyLanguage();
        resetTyping();
      });
    });
  }

  function initNavigation() {
    const menuToggle = $(".menu-toggle");
    const navPanel = $(".nav-panel");
    if (!menuToggle || !navPanel) return;

    function closeMenu() {
      menuToggle.setAttribute("aria-expanded", "false");
      navPanel.classList.remove("open");
      document.body.classList.remove("menu-open");
    }

    menuToggle.addEventListener("click", () => {
      const willOpen = menuToggle.getAttribute("aria-expanded") !== "true";
      menuToggle.setAttribute("aria-expanded", String(willOpen));
      navPanel.classList.toggle("open", willOpen);
      document.body.classList.toggle("menu-open", willOpen);
    });

    $$("a", navPanel).forEach((link) => link.addEventListener("click", closeMenu));

    document.addEventListener("click", (e) => {
      if (
        navPanel.classList.contains("open") &&
        !navPanel.contains(e.target) &&
        !menuToggle.contains(e.target)
      ) {
        closeMenu();
      }
    });

    const projectsLink = $('[data-page-link="projects"]', navPanel);
    if (projectsLink && document.body.dataset.page === "projects") {
      projectsLink.classList.add("active");
    }

    if (document.body.dataset.page !== "home") return;

    const sectionLinks = $$("[data-home-section]");
    const sections = $$("main section[id]");
    if (!sectionLinks.length || !sections.length) return;

    const updateActiveSection = () => {
      let currentId = "home";
      sections.forEach((section) => {
        if (section.offsetTop - 120 <= window.scrollY) currentId = section.id;
      });
      sectionLinks.forEach((link) => {
        link.classList.toggle("active", link.dataset.homeSection === currentId);
      });
    };

    window.addEventListener("scroll", updateActiveSection, { passive: true });
    updateActiveSection();
  }

  function initReveal() {
    const elements = $$(".reveal");
    if (!elements.length) return;

    if (!("IntersectionObserver" in window)) {
      elements.forEach((element) => element.classList.add("visible"));
      return;
    }

    const observer = new IntersectionObserver((entries) => {
      entries.forEach((entry) => {
        if (!entry.isIntersecting) return;
        entry.target.classList.add("visible");
        observer.unobserve(entry.target);
      });
    }, { threshold: 0.1 });

    elements.forEach((element) => observer.observe(element));
  }

  function applyFilter(controls, filterKey) {
    const group = controls.dataset.filterControls;
    const grid = $(`[data-filter-grid="${group}"]`);
    if (!grid) return;

    const items = $$("[data-category]", grid);
    let visibleCount = 0;

    items.forEach((item) => {
      const visible = filterKey === "all" || item.dataset.category === filterKey;
      item.hidden = !visible;
      if (visible) visibleCount += 1;
    });

    $$("[data-filter]", controls).forEach((button) => {
      const active = button.dataset.filter === filterKey;
      button.classList.toggle("active", active);
      button.setAttribute("aria-pressed", String(active));
    });

    const emptyState = $(`[data-filter-empty="${group}"]`);
    if (emptyState) emptyState.hidden = visibleCount !== 0;

    const resultCount = $("[data-results-count]");
    if (group === "projects" && resultCount) {
      resultCount.textContent = String(visibleCount).padStart(2, "0");
      const url = new URL(window.location.href);
      if (filterKey === "all") url.searchParams.delete("category");
      else url.searchParams.set("category", filterKey);
      window.history.replaceState({}, "", url);
    }
  }

  function initFilters() {
    $$("[data-filter-controls]").forEach((controls) => {
      const selected = controls.dataset.selectedFilter
        || $("[data-filter].active", controls)?.dataset.filter
        || "all";

      applyFilter(controls, selected);
      controls.addEventListener("click", (event) => {
        const button = event.target.closest("[data-filter]");
        if (!button) return;
        applyFilter(controls, button.dataset.filter);
      });
    });
  }

  function runTyping() {
    const target = $("[data-typing]");
    if (!target) return;

    const words = typingWords[state.lang];
    const word = words[state.typingWordIndex];
    state.typingCharIndex += state.typingDeleting ? -1 : 1;
    target.textContent = word.slice(0, state.typingCharIndex);

    let delay = state.typingDeleting ? 45 : 85;
    if (!state.typingDeleting && state.typingCharIndex === word.length) {
      state.typingDeleting = true;
      delay = 1300;
    } else if (state.typingDeleting && state.typingCharIndex === 0) {
      state.typingDeleting = false;
      state.typingWordIndex = (state.typingWordIndex + 1) % words.length;
      delay = 280;
    }

    state.typingTimer = window.setTimeout(runTyping, delay);
  }

  function resetTyping() {
    window.clearTimeout(state.typingTimer);
    state.typingWordIndex = 0;
    state.typingCharIndex = 0;
    state.typingDeleting = false;
    const target = $("[data-typing]");
    if (!target) return;
    target.textContent = "";
    runTyping();
  }

  function initTestimonials() {
    const root = $("[data-testimonial]");
    if (!root) return;

    const slides = $$("[data-testimonial-slide]", root);
    const dotsRoot = $("[data-testimonial-dots]");
    const previous = $("[data-testimonial-prev]");
    const next = $("[data-testimonial-next]");
    if (!slides.length) return;

    let current = 0;
    let timer;

    const show = (index) => {
      current = (index + slides.length) % slides.length;
      slides.forEach((slide, slideIndex) => {
        slide.hidden = slideIndex !== current;
      });
      $$("[data-testimonial-dot]", dotsRoot || document).forEach((dot, dotIndex) => {
        const active = dotIndex === current;
        dot.classList.toggle("active", active);
        dot.setAttribute("aria-current", String(active));
      });
    };

    const restart = () => {
      window.clearInterval(timer);
      timer = window.setInterval(() => show(current + 1), 5200);
    };

    previous?.addEventListener("click", () => {
      show(current - 1);
      restart();
    });
    next?.addEventListener("click", () => {
      show(current + 1);
      restart();
    });
    dotsRoot?.addEventListener("click", (event) => {
      const dot = event.target.closest("[data-testimonial-dot]");
      if (!dot) return;
      show(Number(dot.dataset.testimonialDot));
      restart();
    });

    show(0);
    restart();
  }

  function initProjectGalleries() {
    $$("[data-project-gallery]").forEach((gallery) => {
      const slides = $$("[data-gallery-slide]", gallery);
      const dots = $$("[data-gallery-dot]", gallery);
      const counter = $("[data-gallery-current]");
      if (!slides.length) return;

      let current = 0;
      const show = (index) => {
        current = (index + slides.length) % slides.length;
        slides.forEach((slide, slideIndex) => {
          slide.hidden = slideIndex !== current;
        });
        dots.forEach((dot, dotIndex) => {
          const active = dotIndex === current;
          dot.classList.toggle("active", active);
          dot.setAttribute("aria-current", String(active));
        });
        if (counter) counter.textContent = String(current + 1).padStart(2, "0");
      };

      $("[data-gallery-prev]", gallery)?.addEventListener("click", () => show(current - 1));
      $("[data-gallery-next]", gallery)?.addEventListener("click", () => show(current + 1));
      dots.forEach((dot) => dot.addEventListener("click", () => show(Number(dot.dataset.galleryDot))));
      gallery.addEventListener("keydown", (event) => {
        if (event.key === "ArrowLeft") show(current + (document.dir === "rtl" ? 1 : -1));
        if (event.key === "ArrowRight") show(current + (document.dir === "rtl" ? -1 : 1));
      });
      show(0);
    });
  }

  function getFieldError(field) {
    const value = field.value.trim();
    const name = field.name.toLowerCase();
    if (name === "name" && value.length < 2) return t("nameError");
    if (name === "email" && !/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(value)) return t("emailError");
    if (name === "subject" && value.length < 3) return t("subjectError");
    if (name === "message" && value.length < 20) return t("messageError");
    return "";
  }

  function initContactForm() {
    const form = $("[data-contact-form]");
    if (!form) return;

    const fields = $$('input:not([type="hidden"]), textarea', form);
    const submitButton = $(".form-submit", form);
    const status = $("[data-form-status]", form);
    let submitting = false;

    const validateField = (field) => {
      const message = getFieldError(field);
      const error = $(`[data-error-for="${field.name}"]`, form);
      if (error) error.textContent = message;
      field.setAttribute("aria-invalid", message ? "true" : "false");
      return !message;
    };

    const updateSubmitState = () => {
      if (submitButton) {
        submitButton.disabled = submitting || fields.some((field) => Boolean(getFieldError(field)));
      }
    };

    fields.forEach((field) => {
      field.addEventListener("blur", () => {
        validateField(field);
        updateSubmitState();
      });
      field.addEventListener("input", () => {
        if (field.getAttribute("aria-invalid") === "true") validateField(field);
        updateSubmitState();
      });
    });

    form.addEventListener("submit", async (event) => {
      event.preventDefault();
      const valid = fields.map(validateField).every(Boolean);
      if (!valid) return;

      submitting = true;
      updateSubmitState();
      if (status) status.textContent = t("formSending");

      try {
        const response = await fetch(form.action, {
          method: form.method || "POST",
          body: new FormData(form),
          headers: {
            Accept: "application/json",
            "X-Requested-With": "XMLHttpRequest"
          }
        });

        const payload = await response.json().catch(() => null);
        if (!response.ok || !payload?.success) {
          throw new Error(payload?.message || t("formError"));
        }

        if (status) status.textContent = payload.message || t("formSuccess");
        form.reset();
        fields.forEach((field) => field.removeAttribute("aria-invalid"));
      } catch (error) {
        if (status) {
          status.textContent = error instanceof Error && error.message
            ? error.message
            : t("formError");
        }
      } finally {
        submitting = false;
        window.setTimeout(updateSubmitState, 0);
      }
    });

    updateSubmitState();
  }

  function initBackToTop() {
    const button = $("[data-back-to-top]");
    if (!button) return;
    button.addEventListener("click", () => window.scrollTo({ top: 0, behavior: "smooth" }));
    const update = () => button.classList.toggle("visible", window.scrollY > 520);
    window.addEventListener("scroll", update, { passive: true });
    update();
  }

  function initHeroMotion() {
    const orbit = $("[data-hero-orbit]");
    if (!orbit || window.matchMedia("(prefers-reduced-motion: reduce)").matches) return;

    window.addEventListener("pointermove", (event) => {
      const x = (event.clientX / window.innerWidth - 0.5) * 14;
      const y = (event.clientY / window.innerHeight - 0.5) * -14;
      orbit.style.transform = `rotateX(${y}deg) rotateY(${x}deg)`;
    }, { passive: true });
  }

  function init() {
    applyTheme();
    applyLanguage();
    initPreferences();
    initNavigation();
    initReveal();
    initFilters();
    resetTyping();
    initTestimonials();
    initProjectGalleries();
    initContactForm();
    initBackToTop();
    initHeroMotion();

    const year = $("[data-year]");
    if (year) year.textContent = new Date().getFullYear();
  }

  document.addEventListener("DOMContentLoaded", init);
})();
