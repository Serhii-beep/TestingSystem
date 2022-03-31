using System.Collections.Generic;

namespace TestingSystem.BLL.Dtos
{
    public class TestDto
    {
        public int Id { get; set; }
        public int TestSetId { get; set; }
        public int CorrectAnswerId { get; set; }
        public QuestionDto Question { get; set; }
        public List<AnswerDto> Answers { get; set; }
        public TestDto()
        {
            Answers = new List<AnswerDto>();
        }
    }
}
