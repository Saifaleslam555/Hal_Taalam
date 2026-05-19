using System.ComponentModel.DataAnnotations;

namespace Hal_Taalam.Enums
{
    public enum CategoryOption
    {
        [Display(Name = "تاريخ")]
        History = 1,
    
    [Display(Name = "جغرافيا")]
        Geography = 2,
    
    [Display(Name = "علوم")]
        Science = 3,
    
    [Display(Name = "ثقافة عامة")]
        GeneralCulture = 4,

    // 👇 القسم الجديد اللي ضفناه
    [Display(Name = "رياضة")]
        Sports = 5
    }
}
