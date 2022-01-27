using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.DAL.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int Points { get; set; }
        public int TestId { get; set; }
        public virtual Test Test { get; set; }
    }
}
