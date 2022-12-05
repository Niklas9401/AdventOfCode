using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Years
{
    public class Day_5_2022
    {
        public string INPUT_PATH =
            Directory.GetParent(Environment.CurrentDirectory)
            .Parent?.Parent?.FullName +
            "/Years/Year_2022/Day 5/Input.txt";

        public Day_5_2022()
        {
            string[] Lines = File.ReadAllLines(INPUT_PATH);
            int index = Array.IndexOf(Lines, "");       //get empty line between current crate positions and instructions

            Stack<string>[] CrateStack = new Stack<string>[9];
            string[] CrateStackMultipleMove = new string[9];
            for (int i = index - 2; i >= 0; i--)
            {
                Console.WriteLine(Lines[i]);
                Lines[i] = Lines[i].Replace("    ", " ");
                string[] cratestring = Lines[i].Split(" ");
                for (int j = 0; j < cratestring.Length; j++)
                {
                    if (CrateStack[j] == null)
                        CrateStack[j] = new Stack<string>();
                    string crate = cratestring[j].Replace("[", "").Replace("]", "");
                    if (crate != "")
                        CrateStack[j].Push(crate);
                    CrateStackMultipleMove[j] += crate;
                }
            }

            for (int i = index + 1; i < Lines.Length; i++)
            {
                string[] instructionString = (Regex.Replace(Lines[i], "[^0-9\\s]", "").Split(" ")).Where(x => x != "").ToArray();
                int[] instructions = Array.ConvertAll(instructionString, x => int.Parse(x));

                int amount = instructions[0];
                int fromStack = instructions[1] - 1;
                int toStack = instructions[2] - 1;

                for (int j = 0; i < amount; j++)
                {
                    CrateStack[toStack].Push(CrateStack[fromStack].Pop());
                }

                string movedCrates = CrateStackMultipleMove[fromStack]
                    .Substring(CrateStackMultipleMove[fromStack].Length - amount, amount);

                CrateStackMultipleMove[fromStack] = CrateStackMultipleMove[fromStack].Substring(0, CrateStackMultipleMove[fromStack].Length - amount);
                CrateStackMultipleMove[toStack] += movedCrates;
            }

            Console.WriteLine("Last Crate of each stack is: \n");
            for (int i = 0; i < CrateStack.Length; i++)
            {
                Console.WriteLine($"Stack {i + 1}: {CrateStack[i].Peek()}");
            }

            Console.WriteLine("\nWhen CrateMover 9001 is used, the last Crate of each stack is: \n");
            for (int i = 0; i < CrateStack.Length; i++)
            {
                Console.WriteLine($"Stack {i + 1}: {CrateStackMultipleMove[i].Substring(CrateStackMultipleMove[i].Length - 1, 1)}");
            }
        }
    }
}
