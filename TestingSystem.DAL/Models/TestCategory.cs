using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
