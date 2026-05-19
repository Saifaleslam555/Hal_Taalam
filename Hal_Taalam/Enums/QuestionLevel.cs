using System.ComponentModel.DataAnnotations;

namespace Hal_Taalam.Enums
{
    public enum QuestionLevel
    {
        [Display(Name = "سهل")]
        Easy = 1,

        [Display(Name = "متوسط")]
        Medium = 2,

        [Display(Name = "صعب")]
        Hard = 3
    }
}
