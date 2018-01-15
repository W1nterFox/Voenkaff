using System.Collections.Generic;

namespace Voenkaff.Wrappers
{
    class JsonTestWrapper
    {
        public string Name { get; set; }
        public List<string> Tasks { get; set; }

        public JsonTestWrapper()
        {
            Tasks = new List<string>();
        }
    }
}
