using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year_2022.Day_1
{
    public class Elve
    {
        public int Number { get; set; }
        public int Calories { get; set; }

        public Elve(int count, int calories)
        {
            Number = count;
            Calories = calories;
        }
    }
}
