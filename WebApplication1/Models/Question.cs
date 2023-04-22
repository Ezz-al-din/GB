using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.ViewModel;

namespace WebApplication1.Models
{
    public class Question
    {
        
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int CorrectAnswer { get; set; }
        public int Marks { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}
