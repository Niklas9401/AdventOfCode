using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Years
{
    public class Day_3_2022
    {
        public string INPUT_PATH =
             Directory.GetParent(Environment.CurrentDirectory)
             .Parent?.Parent?.FullName +
             "/Years/Year_2022/Day 3/Input.txt";


        public Day_3_2022()
        {

            string[] Lines = File.ReadAllLines(INPUT_PATH);

            int TotalPriority = 0;

            foreach (string Line in Lines)
            {
                int LineLength = Line.Length;
                char[] all = Line.ToCharArray();
                char[] first = all[0..(LineLength / 2)];
                char[] last = all[(LineLength / 2)..(LineLength)];
                char[] duplicates = first.Intersect(last).ToArray();


                foreach (char c in duplicates)
                {
                    //Check if char is upper or lowercase to get ascii offset
                    int offset = c - 96 > 0 ? 96 : 38;
                    TotalPriority += c - offset;
                }
            }

            Console.WriteLine(TotalPriority.ToString());

            // ------------ TWO ----------------

            for (int i = 0; i < Lines.Length / 3; i++)
            {
                if (3 * i - 2 < Lines.Length)
                {
                    char[] bag1 = Lines[3 * i].ToCharArray();
                    char[] bag2 = Lines[3 * i + 1].ToCharArray();
                    char[] bag3 = Lines[3 * i + 2].ToCharArray();

                    char commonItem = bag1.Intersect(bag2.Intersect(bag3)).FirstOrDefault();
                    int offset = commonItem - 96 > 0 ? 96 : 38;
                    TotalPriority += commonItem - offset;
                }
            }

            Console.WriteLine(TotalPriority.ToString());


        }

    }
}
