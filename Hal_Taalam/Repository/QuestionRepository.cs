using Hal_Taalam.Models;
using Hal_Taalam.Models.DBcontext;
using Hal_Taalam.Repository.Interface;
using Hal_Taalam.ViewModel.Questions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Hal_Taalam.Repository
{
    public class QuestionRepository : GenericRepository<Question>, IQusetionRepository
    {
       
        private readonly HalTaalamContext context;
        
        public QuestionRepository(HalTaalamContext context): base(context) 
        {
            this.context = context;
        }
     

        public double CalcScore(Question question)
        {
            throw new NotImplementedException();
        }

        public double GetFinalScore(Question question)
        {
            throw new NotImplementedException();
        }

        public bool IsCorrect(Question question)
        {
            throw new NotImplementedException();
        }


        public int CountQuestions() 
        {
            return context.Questions.Count();
        }
        
        
        public List<Question> GetRandomQuestion() 
        {
             var RandomQuestion = context.Questions.
                OrderBy(q=>Guid.NewGuid()).
                Take(10).
                ToList();

            return RandomQuestion;
        }

        
    }

}
