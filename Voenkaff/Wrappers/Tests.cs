using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voenkaff.Wrappers
{
    public class Tests
    {
        public ICollection<Test> TestList { get; set; }
        public Dictionary<string, List<string>> PlatoonList { get; set; }
    }
}
