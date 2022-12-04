namespace AdventOfCode.Years
{
    public class Day_1_2021
    {
        public string INPUT_PATH =
               Directory.GetParent(Environment.CurrentDirectory)
               .Parent?.Parent?.FullName +
               "/Years/Year_2021/Day 1/Input.txt";

        public Day_1_2021() {
            string[] lines = File.ReadAllLines(INPUT_PATH);

            int IncreaseCount = 0;
            int LastMeasurement = 0;

            int[] lineInt = Array.ConvertAll(lines, l => int.Parse(l));

            for (int i = 0; i < lines.Count(); i++)
            {
                if (i == 0) LastMeasurement = lineInt[0];
                if (lineInt[i] > LastMeasurement)
                {
                    IncreaseCount++;
                }
                LastMeasurement = lineInt[i];
            }
            Console.WriteLine($"Measurement increasements (compared one by one): {IncreaseCount}");

            for (int i = 0; i < lineInt.Count() - 3; i++)
            {
                int Total = lineInt[i] + lineInt[i + 1] + lineInt[i + 2];
                if (Total > LastMeasurement)
                {
                    IncreaseCount++;
                }
                LastMeasurement = Total;
            }
            Console.WriteLine($"Measurement increasements (compared 3 values): {IncreaseCount}");
        }
    }
}
