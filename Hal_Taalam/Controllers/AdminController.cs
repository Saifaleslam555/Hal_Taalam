using Hal_Taalam.Service;
using Hal_Taalam.Service.IService;
using Hal_Taalam.ViewModel.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hal_Taalam.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminDashboardService adminDashboardService;
        private readonly IAdminQuestionsService adminQuestionsService;

        public AdminController(IAdminDashboardService adminDashboardService,IAdminQuestionsService adminQuestionsService)
        {
            this.adminDashboardService = adminDashboardService;
            this.adminQuestionsService = adminQuestionsService;
        }



        public async Task<IActionResult> AdminDashboard(AdminDashboardVM adminDashboardVM)
        {
            adminDashboardVM = new AdminDashboardVM
            {
                PlayersCount = await adminDashboardService.CountPlayers(),
                RecentPlayers = adminDashboardService.RecentPlayers(),
                CategoriesCount = await adminDashboardService.CountCategories(),
                GamesCount = await adminDashboardService.CountGames(),
                IsDatabaseOnline = adminDashboardService.DatabaseStatus(),
                QuestionsCount=await adminDashboardService.CountQuestions()
            };

            return View("AdminDashboard", adminDashboardVM);
        }


        public IActionResult QuestionList()
        {
            List<QuestionListVM> list=adminQuestionsService.GetQuestionsList();
            return View("QuestionsList", list);
        }

        public IActionResult AddQuestion()
        {
            return View();
        }
        public async Task<IActionResult> CreationQuestion(CreateQuestionVM createQuestionVM) 
        {
            var newQuestion = await adminQuestionsService.CreateQuestion(createQuestionVM);
            return RedirectToAction("QuestionList");
        }

        public async Task<IActionResult> UpdateQuestion(int QuestionId, CreateQuestionVM createQuestionVM)
        {
            await adminQuestionsService.UpdateQuestion(QuestionId, createQuestionVM);

            return RedirectToAction("QuestionList");
        }

        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await adminQuestionsService.DeleteQuestion(id);
            return RedirectToAction("QuestionList");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var questionVM = await adminQuestionsService.GetQuestionById(id);

            if (questionVM == null)
            {
                return NotFound();
            }

            return View("AddQuestion", questionVM);
        }

        public IActionResult Users()
        {
            return View();
        }  
        public IActionResult Reporst()
        {
            return View();
        }
    }
}
