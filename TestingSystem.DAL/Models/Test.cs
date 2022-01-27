using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.DAL.Models
{
    public class Test
    {
        public int Id { get; set; }
        public int CorrectAnswerId { get; set; }
        public int TestSetId { get; set; }
        public virtual TestSet TestSet { get; set; }
        public virtual Question Question { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        
        public Test()
        {
            Answers = new List<Answer>();
        }
    }
}
