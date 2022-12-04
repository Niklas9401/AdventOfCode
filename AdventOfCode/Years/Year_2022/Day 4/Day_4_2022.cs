using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Years
{
    public class Day_4_2022
    {
        public string INPUT_PATH =
             Directory.GetParent(Environment.CurrentDirectory)
             .Parent?.Parent?.FullName +
             "/Years/Year_2022/Day 4/Input.txt";

        public Day_4_2022()
        {
            string[] Lines = File.ReadAllLines(INPUT_PATH);
            int TotalPairsFullRange = 0;
            int TotalPairsPartRange = 0;

            foreach (string Line in Lines)
            {
                string[] parts = Line.Replace(",", "-").Split("-");
                int[] number = Array.ConvertAll(parts, x => int.Parse(x));
                List<int> pair1 = Enumerable.Range(number[0], number[1] - number[0] + 1).ToList();
                List<int> pair2 = Enumerable.Range(number[2], number[3] - number[2] + 1).ToList();

                if (pair1.All(x => pair2.Contains(x)) || pair2.All(x => pair1.Contains(x)))
                    TotalPairsFullRange++;
            
                if (pair1.Intersect(pair2).Any())
                {
                    TotalPairsPartRange++;
                }
            }

            Console.WriteLine($"Assignments where one range contains the other: {TotalPairsFullRange}");
            Console.WriteLine($"Assignments where one range overlaps the other: {TotalPairsPartRange}");
        }
    }
}
