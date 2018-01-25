using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voenkaff.Wrappers
{
    public class Tests
    {
        public List<Test> TestList { get; set; }=new List<Test>();
        public Dictionary<string, List<string>> PlatoonList { get; set; }=new Dictionary<string, List<string>>();
        public List<string> CourseList { get; set; } = new List<string>();
    }
}
