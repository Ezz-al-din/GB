using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class QuizController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly QuizService _quizService;

        public QuizController(ApplicationDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _quizService = new QuizService(context,memoryCache);
        }

        [HttpPost("createQuiz")]
        public IActionResult CreateQuiz(List<Question> questions,Quiz quiz)
        {
            Quiz quiz1 = new Quiz()
            {
                QuizName= quiz.QuizName,
                Questions=questions,
                TimeLimit=quiz.TimeLimit
            };
            _context.SaveChanges();
            return Ok(quiz1);
        }

        [HttpGet("{quizId}")]
        public IActionResult GetQuiz(int quizId)
        {
            // retrieve the quiz from the database or in-memory cache
            Quiz quiz = _quizService.GetQuiz(quizId);
            if (quiz == null)
            {
                return NotFound();
            }

            // return the quiz details in JSON format
            return Ok(quiz);
        }

        [HttpPost("{quizId}/start")]
        public IActionResult StartQuiz(int quizId)
        {
            // store the start time of the quiz in the database or in-memory cache
            _quizService.StartQuiz(quizId, DateTime.Now);

            return Ok();
        }

        [HttpGet("{quizId}/questions/{questionId}")]
        public IActionResult GetQuestion(int quizId, int questionId)
        {
            // retrieve the question from the database or in-memory cache
            Question question = _quizService.GetQuestion(quizId, questionId);
            if (question == null)
            {
                return NotFound();
            }

            // return the question details in JSON format
            return Ok(question);
        }

        [HttpPost("{quizId}/questions/{questionId}/answer")]
        public IActionResult SubmitAnswer(int quizId, int questionId, int answer)
        {
            // store the student's answer in the database or in-memory cache
            _quizService.SubmitAnswer(quizId, questionId, answer);

            return Ok();
        }

        [HttpGet("{quizId}/result")]
        public IActionResult GetResult(int quizId)
        {
            // retrieve the quiz and student's answers from the database or in-memory cache
            Quiz quiz = _quizService.GetQuiz(quizId);
            List<Answer> answers = _quizService.GetAnswers(quizId);

            // calculate the total marks for the quiz
            int totalMarks = 0;
            foreach (Question question in quiz.Questions)
            {
                Answer answer = answers.FirstOrDefault(a => a.QuestionId == question.QuestionId);
            }
            return Ok(totalMarks);
            
        }
    }
}
