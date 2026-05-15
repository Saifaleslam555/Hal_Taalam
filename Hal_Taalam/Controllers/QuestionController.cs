using Microsoft.AspNetCore.Mvc;
using Hal_Taalam.Repository.Interface;
using Hal_Taalam.Models;
using Hal_Taalam.Repository;
using Hal_Taalam.Extensions;
using Hal_Taalam.ViewModel.Questions;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Hal_Taalam.Data;

namespace Hal_Taalam.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly IQusetionRepository qusetionRepository;
        private readonly IPlayerRepository playerRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IGameResultRepository gameResultRepository;

        //private readonly Question question;

        public QuestionController(IQusetionRepository qusetionRepository,
            IPlayerRepository playerRepository,
            UserManager<ApplicationUser> userManager,
            IGameResultRepository gameResultRepository)
        {
            this.qusetionRepository = qusetionRepository;
            this.playerRepository = playerRepository;
            this.userManager = userManager;
            this.gameResultRepository = gameResultRepository;
        }

        public IActionResult StartQuiz()
        {
            List<Question> questions = qusetionRepository.GetRandomQuestion();

            HttpContext.Session.SetObjectAsJson("Questions",questions);
            HttpContext.Session.SetInt32("index", 0);
            HttpContext.Session.SetInt32("Score",0);
            return RedirectToAction(nameof(Question));
        }

        public IActionResult Question() 
        {
            var question = HttpContext.Session.GetOjectFromJson<List<Question>>("Questions");
            if (question == null)
            {
                return RedirectToAction(nameof(StartQuiz));
            }
            var index = HttpContext.Session.GetInt32("index") ?? 0;

            if (index >= question.Count()) return RedirectToAction(nameof(Result));

            var q = question[index];

            var quiz = new QuizVM
            {
                QuestionVM = new QuestionVM
                {

                    question = q.question,
                    answer1 = q.Answer1,
                    answer2 = q.Answer2,
                    answer3 = q.Answer3,
                    answer4 = q.Answer4,
                    correctAnswer = q.CorrectAnswer

                },
                index = index,
                total = question.Count()
            };

            return View("Quiz",quiz);
        }

        public IActionResult Answer(int questionID,int selectedAnswer) 
        {

            var question = HttpContext.Session.GetOjectFromJson<List<Question>>("Questions");
            int index=HttpContext.Session.GetInt32("index") ??0;
            //int Total = HttpContext.Session.GetInt32("Total") ?? 0;
            int score = HttpContext.Session.GetInt32("Score") ?? 0;

            var CurrentQuestion=question[(int)index];

            if (selectedAnswer == CurrentQuestion.CorrectAnswer)
            {
                score++;
                HttpContext.Session.SetInt32("Score", score);
            }
            else 
            {

            }

            index++;
            HttpContext.Session.SetInt32("index",index);
            
            if(index>=question.Count())
                return RedirectToAction(nameof(Result)) ;

            return RedirectToAction(nameof(Question));


        }

        public async Task<IActionResult> Result() 
        {
            int? Score = HttpContext.Session.GetInt32("Score");
            var question = HttpContext.Session.GetOjectFromJson<List<Question>>("Questions");
            //  int? total = HttpContext.Session.GetInt32("Total");

            int total = question?.Count ??0;



            ResultVM resultVM = new ResultVM();

            resultVM.Total = total;
            resultVM.Score = Score;

            string userid= userManager.GetUserId(User);

            var gamaResult = new GameResults();
            gamaResult.playerId = int.Parse(userid);
            gamaResult.score = Score ?? 0;
            gamaResult.PlayerName = User.Identity.Name;
            gamaResult.DatePlayed= DateTime.Now;
            
            gameResultRepository.Add(gamaResult);


            await playerRepository.UpdateStats(resultVM.Score,userid);

            return View("Result",resultVM);
        }
    }
}
