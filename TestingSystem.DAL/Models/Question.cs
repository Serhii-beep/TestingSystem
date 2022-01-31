namespace TestingSystem.DAL.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int Points { get; set; }
        public int TestId { get; set; }
    }
}
