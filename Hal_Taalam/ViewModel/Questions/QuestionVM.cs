using Hal_Taalam.Enums;

namespace Hal_Taalam.ViewModel.Questions
{
    public class QuestionVM
    {
        public string question { get; set; }

        
        public string answer1 { get; set; }
        public string answer2 { get; set; }
        public string answer3 { get; set; }
        public string answer4 { get; set; }

        public CorrectAnswerOption correctAnswer { get; set; }
    }
}
