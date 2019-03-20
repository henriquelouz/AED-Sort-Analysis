using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AED_P1
{
    class Result
    {
        public int attempt { get; set; }
        public int sample { get; set; }
        public long bubble { get; set; }
        public long selection { get; set; }
        public long insertion { get; set; }
        public long quick { get; set; }
        public long merge { get; set; }
        public long mixed { get; set; }
    }
}
