namespace TestingSystem.DAL.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public int TestId { get; set; }
        public virtual Test Test { get; set; }
    }
}
