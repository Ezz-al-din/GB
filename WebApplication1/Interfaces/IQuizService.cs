using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IQuizService 
    {
        public Quiz GetQuiz(int quizId);
        public void StartQuiz(int quizId, DateTime startTime);
        public Question GetQuestion(int quizId, int questionId);
        public void SubmitAnswer(int quizId, int questionId, int answer);
        public List<Answer> GetAnswers(int quizId);
        public int CalculateTotalMarks(int quizId);
    }
}
