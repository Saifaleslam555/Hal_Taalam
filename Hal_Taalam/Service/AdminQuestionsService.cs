using Hal_Taalam.Enums;
using Hal_Taalam.Models;
using Hal_Taalam.Repository.UnitOfWork;
using Hal_Taalam.Service.IService;
using Hal_Taalam.ViewModel.Admin;

namespace Hal_Taalam.Service
{
    public class AdminQuestionsService : IAdminQuestionsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminQuestionsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateQuestion(CreateQuestionVM createQuestionVM)
        {

            try
            {
                var newQuestion = new Question()
                {
                    question = createQuestionVM.Question,
                    Answer1 = createQuestionVM.Answer1,
                    Answer2 = createQuestionVM.Answer2,
                    Answer3 = createQuestionVM.Answer3,
                    Answer4 = createQuestionVM.Answer4,
                    CorrectAnswer = createQuestionVM.CorrectAnswer,
                    CategoryID = (int)createQuestionVM.Category,
                    Level = createQuestionVM.Level
                };
                if (newQuestion == null)
                {
                    return false;
                }

                await _unitOfWork.Question.Add(newQuestion);
                await _unitOfWork.Commit();

                return true;
            }
            catch (Exception ex) { 
                return false;            
            }

            
        }

        public async Task<bool> DeleteQuestion(int QuestionId)
        {
            if (QuestionId == 0) { return false; }
            try
            {
                var question = _unitOfWork.Question.GetOne(q => q.Id == QuestionId);
                _unitOfWork.Question.DeleteById(question);
                await _unitOfWork.Commit();

                return true;
            }
            catch (Exception ex) { return false; }
        }

        public List<QuestionListVM> GetQuestionsList()
        {
            List<Question> list = _unitOfWork.Question.GetAll()
                .OrderByDescending(q => q.Id)
                .Take(10)
                .ToList();

            var questionViewModels = list.Select(q => new QuestionListVM
            {
                Id = q.Id,
                QuestionText = q.question,
                CategoryID = (CategoryOption)q.CategoryID,
                Level = q.Level,
                Answer1 = q.Answer1,
                Answer2 = q.Answer2,
                Answer3 = q.Answer3,
                Answer4 = q.Answer4,
                CorrectAnswer = q.CorrectAnswer
            }).ToList();

            return questionViewModels;
        }


        public async Task<bool> UpdateQuestion(int QuestionId,CreateQuestionVM createQuestionVM)
        {
            try { 
            var existingQuestion= _unitOfWork.Question.GetOne(p=>p.Id== QuestionId);

            if (existingQuestion == null) {
                
                return false;
            }

            existingQuestion.question = createQuestionVM.Question;
            existingQuestion.Answer1 = createQuestionVM.Answer1;
            existingQuestion.Answer2 = createQuestionVM.Answer2;
            existingQuestion.Answer3 = createQuestionVM.Answer3;
            existingQuestion.Answer4 = createQuestionVM.Answer4;
            existingQuestion.CorrectAnswer = createQuestionVM.CorrectAnswer;
            existingQuestion.CategoryID = (int)createQuestionVM.Category;
            existingQuestion.Level = createQuestionVM.Level;

            _unitOfWork.Question.Update(existingQuestion);
            await _unitOfWork.Commit();
                
                return true;
            } catch (Exception ex) { return false; }
        }
    }
}
