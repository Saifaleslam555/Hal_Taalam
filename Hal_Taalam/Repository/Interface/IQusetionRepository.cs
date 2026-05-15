using Hal_Taalam.Models;

namespace Hal_Taalam.Repository.Interface
{
    public interface IQusetionRepository:IGenericRepository<Question>
    {
        //public string ShowQuestion(Question question);
        public bool IsCorrect(Question question);
        public double CalcScore(Question question);
        public double GetFinalScore(Question question);

        public List<Question> GetRandomQuestion();
        public int CountQuestions();

        //public string Quiz();


    }
}
