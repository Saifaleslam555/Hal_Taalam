using Hal_Taalam.Enums;

namespace Hal_Taalam.ViewModel.Admin
{
    public class QuestionListVM
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public CategoryOption CategoryID { get; set; }
        public QuestionLevel Level { get; set; }
        // ضفنا دول عشان نحتاجهم في نافذة التعديل
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public CorrectAnswerOption CorrectAnswer { get; set; }
    }
}
