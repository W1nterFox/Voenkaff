using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voenkaff.Wrappers
{
    class JsonTaskWrapper
    {
        public string Name { get; set; }
        public List<string> TaskElements { get; set; }

        public JsonTaskWrapper()
        {
            TaskElements = new List<string>();
        }
    }
}
