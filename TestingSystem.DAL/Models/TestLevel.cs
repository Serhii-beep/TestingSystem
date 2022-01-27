using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.DAL.Models
{
    public class TestLevel
    {
        public int Id { get; set; }
        public string DifficultyLevel { get; set; }
        public ICollection<TestSet> TestSets { get; set; }
        public TestLevel()
        {
            TestSets = new List<TestSet>();
        }
    }
}
