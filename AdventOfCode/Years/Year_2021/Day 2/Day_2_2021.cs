using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Years
{
    public class Day_2_2021
    {
        public string INPUT_PATH =
            Directory.GetParent(Environment.CurrentDirectory)
            .Parent?.Parent?.FullName +
            "/Years/Year_2021/Day 2/Input.txt";


        public Day_2_2021()
        {
            string[] lines = File.ReadAllLines(INPUT_PATH);
            int horizontal = 0;
            int depth = 0;
            int depthWithAim = 0;
            int aim = 0;

            foreach (string line in lines)
            {
                string[] parts = line.Split(" ");
                switch (parts[0])
                {
                    case "down":
                        depth += int.Parse(parts[1]);
                        aim += int.Parse(parts[1]);
                        break;
                    case "up":
                        depth -= int.Parse(parts[1]);
                        aim -= int.Parse(parts[1]);
                        break;
                    case "forward":
                        horizontal+= int.Parse(parts[1]);
                        depthWithAim += aim * int.Parse(parts[1]);
                        break;
                }
            }

            Console.WriteLine($"Horizontal and depth multiplied: {horizontal*depth}");
            Console.WriteLine($"Horizontal and depth multiplied (with aim of submarine): {horizontal* depthWithAim}");

        }
    }
}
