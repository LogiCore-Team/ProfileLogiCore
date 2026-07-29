using System.ComponentModel.DataAnnotations;

namespace Portflio.Data.Entities;

public sealed class Testimonial
{
    public int Id { get; set; }

    [Required(ErrorMessage = "الاقتباس بالعربية مطلوب.")]
    [StringLength(2000, ErrorMessage = "يجب ألا يتجاوز الاقتباس 2000 حرف.")]
    public string QuoteAr { get; set; } = string.Empty;

    [Required(ErrorMessage = "الاقتباس بالإنجليزية مطلوب.")]
    [StringLength(2000, ErrorMessage = "يجب ألا يتجاوز الاقتباس 2000 حرف.")]
    public string QuoteEn { get; set; } = string.Empty;

    [Required(ErrorMessage = "الاسم بالعربية مطلوب.")]
    [StringLength(200, ErrorMessage = "يجب ألا يتجاوز الاسم 200 حرف.")]
    public string NameAr { get; set; } = string.Empty;

    [Required(ErrorMessage = "الاسم بالإنجليزية مطلوب.")]
    [StringLength(200, ErrorMessage = "يجب ألا يتجاوز الاسم 200 حرف.")]
    public string NameEn { get; set; } = string.Empty;

    [Required(ErrorMessage = "اسم الشركة بالعربية مطلوب.")]
    [StringLength(200, ErrorMessage = "يجب ألا يتجاوز اسم الشركة 200 حرف.")]
    public string CompanyAr { get; set; } = string.Empty;

    [Required(ErrorMessage = "اسم الشركة بالإنجليزية مطلوب.")]
    [StringLength(200, ErrorMessage = "يجب ألا يتجاوز اسم الشركة 200 حرف.")]
    public string CompanyEn { get; set; } = string.Empty;

    [Range(1, 5, ErrorMessage = "يجب أن يكون التقييم بين نجمة واحدة و5 نجوم.")]
    public int Rating { get; set; } = 5;

    [Range(0, int.MaxValue, ErrorMessage = "يجب ألا يكون ترتيب العرض سالبًا.")]
    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; } = true;
}
