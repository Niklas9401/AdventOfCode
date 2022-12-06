using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Years
{
    public class Day_6_2022
    {
        public string INPUT_PATH =
            Directory.GetParent(Environment.CurrentDirectory)
            .Parent?.Parent?.FullName +
            "/Years/Year_2022/Day 6/Input.txt";

        public int GetSequenceIndex(char[] InputChar, int LengthOfSequence)
        {
            int index = 0;
            int shiftCount = 0;
            for (int i = 0; i < InputChar.Length; i++)
            {
                if (i + LengthOfSequence < InputChar.Length)
                {
                    shiftCount++;
                    char[] temp = new char[LengthOfSequence];
                    for (int j = 0; j < LengthOfSequence; j++)
                    {
                        temp[j] = (InputChar[i + j]);
                    }

                    if (temp.Distinct().Count() == LengthOfSequence)
                    {
                        index = shiftCount + LengthOfSequence - 1;
                        break;
                    }
                }
            }
            return index;
        }

        public Day_6_2022()
        {
            string Input = File.ReadAllText(INPUT_PATH);
            char[] InputChars = Input.ToCharArray();
            int result1 = GetSequenceIndex(InputChars, 4);
            int result2 = GetSequenceIndex(InputChars, 14);
            Console.WriteLine($"Characters processed until detected the start-of-packet marker: {result1}");
            Console.WriteLine($"Characters processed until detected the start-of-message marker: {result2}");
        }
    }
}

