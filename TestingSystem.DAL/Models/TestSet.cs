using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.DAL.Models
{
    public class TestSet
    {
        public int Id { get; set; }
        public int TestCategoryId { get; set; }
        public int TestLevelId { get; set; }
        public virtual TestLevel TestLevel { get; set; }
        public virtual TestCategory TestCategory { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
        public TestSet()
        {
            Tests = new List<Test>();
        }
    }
}
