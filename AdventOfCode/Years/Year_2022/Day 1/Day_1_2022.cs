
using AdventOfCode.Year_2022.Day_1;

namespace AdventOfCode.Years
{
    public class Day_1_2022
    {

        public string INPUT_PATH =
         Directory.GetParent(Environment.CurrentDirectory)
         .Parent?.Parent?.FullName +
         "/Years/Year_2022/Day 1/Input.txt";

        public Day_1_2022()
        {
            int elveNo = 0;
            int topElveCal = 0;
            int topElveNo = 0;
            List<Elve> elves = new();

            foreach (string line in File.ReadAllLines(INPUT_PATH))
            {
                if (string.IsNullOrEmpty(line))
                {
                    Elve lastElve = elves.ElementAt(elves.Count - 1);
                    if (lastElve.Calories > topElveCal)
                    {
                        topElveCal = lastElve.Calories;
                        topElveNo = lastElve.Number;
                    }
                    elveNo++;
                    continue;
                }

                if (elves.Count > elveNo)
                {
                    elves.ElementAt(elveNo).Calories += int.Parse(line);
                }
                else
                {
                    elves.Add(new Elve(elveNo, int.Parse(line)));
                }
            }

            List<Elve> topElves = elves.OrderByDescending(elve => elve.Calories).Take(3).ToList();
            Console.WriteLine($"Elve with the most calories is Elve No. {topElveNo + 1} ({topElveCal} calories)!");
            Console.WriteLine($"Total sum of calories by top 3 elves: {topElves.Sum(x => x.Calories)}");
        }
    }
}
