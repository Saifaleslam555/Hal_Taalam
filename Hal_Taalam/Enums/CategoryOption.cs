using System.ComponentModel.DataAnnotations;

namespace Hal_Taalam.Enums
{
    public enum CategoryOption
    {
        [Display(Name = "تاريخ")]
        History = 5,

        [Display(Name = "جغرافيا")]
        Geography = 6,

        [Display(Name = "علوم")]
        Science = 7,

        [Display(Name = "ثقافة عامة")]
        GeneralCulture = 8,

        [Display(Name = "رياضة")]
        Sports = 9
    }
}
