using Hal_Taalam.Enums;

namespace Hal_Taalam.ViewModel.Admin
{
    public class CreateQuestionVM
    {
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }

        public CorrectAnswerOption CorrectAnswer { get; set; }
        public QuestionLevel Level { get; set; }
        public CategoryOption Category { get; set; }
    }
        //public int CorrectAnswer { get; set; }
        //public int Level { get; set; }
}
