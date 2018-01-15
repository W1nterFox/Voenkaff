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
        public List<string> TaskElement { get; set; }

        public JsonTaskWrapper()
        {
            TaskElement = new List<string>();
        }
    }
}
