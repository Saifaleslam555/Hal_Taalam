using System.ComponentModel.DataAnnotations;

namespace Hal_Taalam.Enums
{
    public enum CorrectAnswerOption
    {
        [Display(Name = "الإجابة الأولى")]
        Answer1 = 1,

        [Display(Name = "الإجابة الثانية")]
        Answer2 = 2,

        [Display(Name = "الإجابة الثالثة")]
        Answer3 = 3,

        [Display(Name = "الإجابة الرابعة")]
        Answer4 = 4
    }
}
