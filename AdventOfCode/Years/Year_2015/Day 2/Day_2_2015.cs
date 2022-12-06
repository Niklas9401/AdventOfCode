using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Years
{
    public class Day_2_2015
    {
        public string INPUT_PATH =
             Directory.GetParent(Environment.CurrentDirectory)
             .Parent?.Parent?.FullName +
             "/Years/Year_2015/Day 2/Input.txt";

        public Day_2_2015()
        {
            string[] Lines = File.ReadAllLines(INPUT_PATH);
            int TotalSquareFeetPaper = 0;
            int TotalSquareFeetRibbon = 0;
            foreach (string Line in Lines)
            {
                string[] MeasurementString = Line.Split('x');
                int[] CalculatedSide = new int[3];
                int[] Measurements = Array.ConvertAll(MeasurementString, int.Parse);

                CalculatedSide[0] = 2 * Measurements[0] * Measurements[1];
                CalculatedSide[1] = 2 * Measurements[1] * Measurements[2];
                CalculatedSide[2] = 2 * Measurements[2] * Measurements[0];
                TotalSquareFeetPaper += CalculatedSide.Sum();

                for (int i = 0; i < 3; i++)
                {
                    CalculatedSide[i] = CalculatedSide[i] / 2;
                }
                TotalSquareFeetRibbon += 2 * Measurements[0] + 2 * Measurements[1];
                TotalSquareFeetRibbon += Measurements[0] * Measurements[1] * Measurements[2];
                TotalSquareFeetPaper += CalculatedSide.Min();

            }
            Console.WriteLine($"The elves need {TotalSquareFeetPaper} square feet of wrapping paper");
            Console.WriteLine($"The elves need {TotalSquareFeetRibbon} feet of ribbon");
        }
    }
}
