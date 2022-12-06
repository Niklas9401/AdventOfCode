using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Years
{
    public class Day_1_2015
    {
        public string INPUT_PATH =
         Directory.GetParent(Environment.CurrentDirectory)
         .Parent?.Parent?.FullName +
         "/Years/Year_2015/Day 1/Input.txt";

        public Day_1_2015() {
            string Input = File.ReadAllText(INPUT_PATH);
            char[] chars= Input.ToCharArray();
            int floorCount = 0;
            int basementEnteredPos = 0;
            bool BasementWasEntered = false;

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '(')
                    floorCount++;
                else
                {
                    floorCount--;
                    if (floorCount < 0 && !BasementWasEntered)
                    {
                        BasementWasEntered= true;
                        basementEnteredPos = i + 1;
                    }
                }
            }
            Console.WriteLine($"Santa is on floor: {floorCount}");
            Console.WriteLine($"Santa gets to the basement at instruction number: {basementEnteredPos}");
        }
        
    }
}
