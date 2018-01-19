using System.Collections.Generic;

namespace Voenkaff.Wrappers
{
    public class Test
    {
        public string Name { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();
        public Marks Marks { get; set; }
    }
}