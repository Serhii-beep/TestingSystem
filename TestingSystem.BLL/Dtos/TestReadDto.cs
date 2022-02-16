using System.Collections.Generic;

namespace TestingSystem.BLL.Dtos
{
    public class TestReadDto
    {
        public int Id { get; set; }
        public int TestSetId { get; set; }
        public QuestionDto Question { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
