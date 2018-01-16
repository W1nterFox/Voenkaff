﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voenkaff.Wrappers
{
    class JsonObjectWrapper
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Answer { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Point Point { get; set; }
        public string Media { get; set; }
    }
}