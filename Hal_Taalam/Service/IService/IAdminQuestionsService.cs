using Hal_Taalam.Models;
using Hal_Taalam.ViewModel.Admin;

namespace Hal_Taalam.Service.IService
{
    public interface IAdminQuestionsService
    {
        public Task<bool> CreateQuestion(CreateQuestionVM createQuestionVM);
        public Task<bool> UpdateQuestion(int QuestionId, CreateQuestionVM createQuestionVM);
        public Task<bool> DeleteQuestion(int QuestionId);
        public Task<CreateQuestionVM> GetQuestionById(int id);
        public List<QuestionListVM> GetQuestionsList();
    }
}
