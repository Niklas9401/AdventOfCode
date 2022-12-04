using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Years
{
    public class Day_2_2022
    {
        public string INPUT_PATH =
             Directory.GetParent(Environment.CurrentDirectory)
             .Parent?.Parent?.FullName +
             "/Years/Year_2022/Day 2/Input.txt";
        public Day_2_2022()
        {
            string[] OpponentTurn = new string[] { "A", "B", "C" };
            string[] OwnTurn = new string[] { "X", "Y", "Z" };

            string[] Lines = File.ReadAllLines(INPUT_PATH);

            int Score = 0;
            foreach (string line in Lines)
            {
                string[] s = line.Split(" ");
                int Opponent = Array.IndexOf(OpponentTurn, s[0]) + 1;
                int Myself = Array.IndexOf(OwnTurn, s[1]) + 1;



                if (Opponent == Myself)
                {
                    Score += 3;
                }
                else if ((Opponent == 1 && Myself == 2) || (Opponent == 2 && Myself == 3) || (Opponent == 3 && Myself == 1))
                {
                    Score += 6;
                }
                Score += Myself;
            }

            Console.WriteLine(Score);

            // ---- TWO

            foreach (string line in Lines)
            {
                string[] s = line.Split(" ");
                int Opponent = Array.IndexOf(OpponentTurn, s[0]) + 1;
                int Myself = Array.IndexOf(OwnTurn, s[1]) + 1;

                switch (Myself)
                {
                    case 1:
                        Myself = Opponent + 2 - 3;
                        if (Myself == 0) Myself = 3;
                        break;
                    case 2:
                        Myself = Opponent;
                        Score += 3;
                        break;
                    case 3:
                        Myself = Opponent + 1;
                        if (Myself == 4) Myself = 1;
                        Score += 6;
                        break;
                }
                Score += Myself;
            }

            Console.WriteLine(Score);
        }
    }
}
