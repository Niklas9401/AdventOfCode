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
            int[] usages = new int[5];

            foreach (string Line in Lines)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (Line[i] == '1')
                        usages[i] += 1;
                }
            }
            string result = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                    result += Convert.ToInt32(usages[i] >= Lines.Length/2);
            }
            
            BitArray gammaRate = new BitArray(result.Select(c => c == '1').ToArray());
            BitArray epsilonRate = new BitArray(result.Select(c => c == '0').ToArray());
            int[] resultEpsilon = new int[1];
            int[] resultGamma = new int[1];
            gammaRate.CopyTo(resultGamma, 0);
            epsilonRate.CopyTo(resultEpsilon, 0);
            Console.WriteLine($"The gammarate is: {resultGamma[0]} The epsilonrate is: {resultEpsilon[0]}\n");
            Console.WriteLine($"Power consumption: {resultGamma[0] * resultEpsilon[0]}");
        }
    }
}