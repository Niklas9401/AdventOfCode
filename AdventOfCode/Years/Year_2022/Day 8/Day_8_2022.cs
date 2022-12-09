using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Years
{
    public class Day_8_2022
    {
        public string INPUT_PATH =
            System.IO.Directory.GetParent(Environment.CurrentDirectory)
            .Parent?.Parent?.FullName +
            "/Years/Year_2022/Day 8/Input.txt";

        public Day_8_2022()
        {
            string[] Lines = File.ReadAllLines(INPUT_PATH);
            int[,] matrix = new int[Lines.Length, Lines.Length];
            List<(int, int)> possibleSpots = new();

            for (int i = 0; i < Lines.Length; i++)
            {
                string[] temp = Lines[i].Select(x => x.ToString()).ToArray();
                for (int j = 0; j < temp.Length; j++)
                {
                    matrix[i, j] = int.Parse(temp[j]);
                }
            }

            int VisibleTree = 0;
            for (int i = 0; i < Lines.Length; i++)
            {
                for (int j = 0; j < Lines[i].Length; j++)
                {
                    if (IsTreeAtEdge(i, j, Lines))
                        possibleSpots.Add((i, j));
                    else
                    {
                        int TreeSize = matrix[i, j];

                        int TopTree = matrix[i - 1, j];
                        int BottomTree = matrix[i + 1, j];
                        int LeftTree = matrix[i, j - 1];
                        int RightTree = matrix[i, j + 1];

                        if (IsTreeTallestInColumn(i, j, matrix, TreeSize) || IsTreeTallestInRow(i, j, matrix, TreeSize))
                        {
                            VisibleTree++;
                            possibleSpots.Add((i, j));
                        }
                        bool col = IsTreeTallestInColumn(i, j, matrix, TreeSize);
                        bool row = IsTreeTallestInRow(i, j, matrix, TreeSize);
                    }
                }
            }
            int OffsetTrees = 2 * Lines.Length + 2 * (Lines.Length - 2);
            VisibleTree += OffsetTrees;
            Console.WriteLine($"There are {VisibleTree} trees visible from outside the grid");
            List<int> ScenicScores = new();
            foreach ((int, int) i in possibleSpots)
            {
                ScenicScores.Add(CalculateScenicScore(i.Item1, i.Item2, matrix));
            }

            Console.WriteLine($"Best Scenic score is: {ScenicScores.Max()}");
        }

        public bool IsTreeAtEdge(int i, int j, string[] matrix)
        {
            return (i == 0 || j == 0 || i == matrix.Length - 1 || j == matrix.Length - 1);
        }

        public bool IsTreeTallestInRow(int row, int column, int[,] matrix, int SizeOfTree)
        {
            int[] FromLeft = Enumerable.Range(0, column).Select(x => matrix[row, x]).ToArray();
            int[] FromRight = Enumerable.Range(column + 1, matrix.GetLength(1) - column - 1).Select(x => matrix[row, x]).ToArray();
            return SizeOfTree > FromLeft.Max() || SizeOfTree > FromRight.Max();
        }

        public bool IsTreeTallestInColumn(int row, int column, int[,] matrix, int SizeOfTree)
        {
            int[] FromTop = Enumerable.Range(0, row).Select(x => matrix[x, column]).ToArray();
            int[] FromBottom = Enumerable.Range(row + 1, matrix.GetLength(0) - row - 1).Select(x => matrix[x, column]).ToArray();
            return SizeOfTree > FromTop.Max() || SizeOfTree > FromBottom.Max();
        }

        public int CalculateScenicScore(int row, int column, int[,] matrix)
        {
            int ViewDistanceTop = 0;
            int ViewDistanceBottom = 0;
            int ViewDistanceLeft = 0;
            int ViewDistanceRight = 0;

            int TreeSize = matrix[row, column];

            //ViewDistance Top
            if (row >= 1)
                for (int i = row - 1; i >= 0; i--)
                    if (matrix[i, column] >= TreeSize)
                    {
                        ViewDistanceTop++;
                        break;
                    }
                    else
                        ViewDistanceTop++;
            

            //ViewDistance Bottom
            if (row != matrix.Length - 1)
                for (int i = row + 1; i < matrix.GetLength(1); i++)
                    if (matrix[i, column] >= TreeSize)
                    {
                        ViewDistanceBottom++;
                        break;
                    }
                    else
                        ViewDistanceBottom++;


            //ViewDistance Left
            if (column >= 1)
                for (int i = column - 1; i >= 0; i--)
                    if (matrix[row, i] >= TreeSize)
                    {
                        ViewDistanceLeft++;
                        break;
                    }
                    else
                        ViewDistanceLeft++;

            //ViewDistance Right
            if (column != matrix.Length - 1)
                for (int i = column + 1; i < matrix.GetLength(1); i++)
                    if (matrix[row, i] >= TreeSize)
                    {
                        ViewDistanceRight++;
                        break;
                    }
                    else
                        ViewDistanceRight++;

            return ViewDistanceBottom*ViewDistanceTop*ViewDistanceLeft*ViewDistanceRight;
        }
    }
}
