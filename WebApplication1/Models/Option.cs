namespace WebApplication1.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Options { get; set; }
        public Question Question { get; set; } = new Question();

    }
}
