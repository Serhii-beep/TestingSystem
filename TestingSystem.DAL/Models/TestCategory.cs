using System.Collections.Generic;

namespace TestingSystem.DAL.Models
{
    public class TestCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TestSet> TestSets { get; set; }
        public TestCategory()
        {
            TestSets = new List<TestSet>();
        }
    }
}
