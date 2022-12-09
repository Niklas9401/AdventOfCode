using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Years
{
    public class Day_3_2021
    {
        public string INPUT_PATH =
            Directory.GetParent(Environment.CurrentDirectory)
            .Parent?.Parent?.FullName +
            "/Years/Year_2021/Day 3/Input.txt";

        public Day_3_2021()
        {
            string[] Lines = File.ReadAllLines(INPUT_PATH);
            List<String> OxygenGeneratorRatingLines = Lines.ToList();
            List<String> CO2ScrubberRatingLines = Lines.ToList();
     
            int[] usages = new int[12];

            foreach (string Line in Lines)
            {
                for (int i = 0; i < usages.Length; i++)
                {
                    if (Line[i].Equals('1'))
                    {
                        usages[i] += 1;

                    }
                    else
                    {
                        usages[i] -= 1;
                    }
                }
            }

            for (int i = 0; i < usages.Length; i++)
            {
                if (usages[i] >= 0)
                {
                    OxygenGeneratorRatingLines = OxygenGeneratorRatingLines.Where(x => x.Substring(i, 1) == "1").ToList();
                }
                else
                {
                    OxygenGeneratorRatingLines = OxygenGeneratorRatingLines.Where(x => x.Substring(i, 1) == "0").ToList();
                }
            }

                string Gamma = string.Empty;
            string Epsilon = string.Empty;
            string OxygenGeneratorRating = string.Empty;
            string CO2ScrubberRating = string.Empty;

            for (int i = 0; i < usages.Length; i++)
            {
                Gamma += Convert.ToInt32(usages[i] >= 0);
                Epsilon += Convert.ToInt32(usages[i] < 0);
            }

            int resultGamma = Convert.ToInt32(Gamma, 2);
            int resultEpsilon = Convert.ToInt32(Epsilon, 2);

            Console.WriteLine($"The gammarate is: {resultGamma} The epsilonrate is: {resultEpsilon}\n");
            Console.WriteLine($"Power consumption: {resultGamma * resultEpsilon}");
        }
    }
}