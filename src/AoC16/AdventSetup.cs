using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC16
{
    public class AdventSetup
    {
        public string[] Input { get; set; }

        public virtual string RunFirst()
        {
            return "Not yet implemented";
        }
        public virtual string RunSecond()
        {
            return "Not yet implemented!";
        }

        public virtual string[] GetInput(string day)
        {
            return System.IO.File.ReadAllLines(@"inputs/day" + day + ".txt");
        }
    }
}
