using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    
    public class Quiz
    {
        public int QuizId { get; set; }
        public string QuizName { get; set; }
        public List<Question> Questions { get; set; }
        public int TimeLimit { get; set; }
    }
}
