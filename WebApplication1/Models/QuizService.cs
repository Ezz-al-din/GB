using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WebApplication1.Interfaces;

namespace WebApplication1.Models
{
    public class QuizService : IQuizService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMemoryCache _memoryCache;

        public QuizService(ApplicationDbContext dbContext, IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            _memoryCache = memoryCache;
        }

        public Quiz GetQuiz(int quizId)
        {
            Quiz quiz = _memoryCache.Get<Quiz>(quizId.ToString());
            if (quiz == null)
            {
                quiz = _dbContext.Quizzes.Include(q => q.Questions).FirstOrDefault(q => q.QuizId == quizId);
                if (quiz != null)
                {
                    _memoryCache.Set(quizId.ToString(), quiz, TimeSpan.FromMinutes(30));
                }
            }
            return quiz;
        }

        public void StartQuiz(int quizId, DateTime startTime)
        {
            _memoryCache.Set($"start_{quizId}", startTime, TimeSpan.FromMinutes(30));
        }

        public Question GetQuestion(int quizId, int questionId)
        {
            Quiz quiz = GetQuiz(quizId);
            if (quiz != null)
            {
                return quiz.Questions.FirstOrDefault(q => q.QuestionId == questionId);
            }
            return null;
        }

        public void SubmitAnswer(int quizId, int questionId, int answer)
        {
            List<Answer> answers = _memoryCache.Get<List<Answer>>(quizId.ToString());
            if (answers == null)
            {
                answers = new List<Answer>();
            }
            Answer existingAnswer = answers.FirstOrDefault(a => a.QuestionId == questionId);
            if (existingAnswer == null)
            {
                answers.Add(new Answer { QuestionId = questionId, StudentAnswer = answer });
            }
            else
            {
                existingAnswer.StudentAnswer = answer;
            }
            _memoryCache.Set(quizId.ToString(), answers, TimeSpan.FromMinutes(30));
        }

        public List<Answer> GetAnswers(int quizId)
        {
            return _memoryCache.Get<List<Answer>>(quizId.ToString()) ?? new List<Answer>();
        }

        public int CalculateTotalMarks(int quizId)
        {
            Quiz quiz = GetQuiz(quizId);
            List<Answer> answers = GetAnswers(quizId);
            int totalMarks = 0;
            foreach (Question question in quiz.Questions)
            {
                Answer answer = answers.FirstOrDefault(a => a.QuestionId == question.QuestionId);
                if (answer != null && answer.StudentAnswer == question.CorrectAnswer)
                {
                    totalMarks += question.Marks;
                }
            }
            return totalMarks;
        }
    }

    public class Answer
    {
        public int QuestionId { get; set; }
        public int StudentAnswer { get; set; }
    }

}
