using System.Collections.Generic;

namespace TestingSystem.DAL.Models
{
    public class TestLevel
    {
        public int Id { get; set; }
        public string DifficultyLevel { get; set; }
        public virtual ICollection<TestSet> TestSets { get; set; }
        public TestLevel()
        {
            TestSets = new List<TestSet>();
        }
    }
}
