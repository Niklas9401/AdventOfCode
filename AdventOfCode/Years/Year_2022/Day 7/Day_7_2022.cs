using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Years
{
    public class Day_7_2022
    {
        public string INPUT_PATH =
            System.IO.Directory.GetParent(Environment.CurrentDirectory)
            .Parent?.Parent?.FullName +
            "/Years/Year_2022/Day 7/Input.txt";

        public Day_7_2022()
        {
            string[] Lines = File.ReadAllLines(INPUT_PATH);
            List<AoC_Directory> Dirs= new List<AoC_Directory>();
            AoC_Directory CurrentDirectory = new AoC_Directory(null, "/");
            Dirs.Add(CurrentDirectory);
            
            foreach (string Line in Lines)
            {
                string[] Parts = Line.Split(' ');

                if (Parts[0].Equals("$"))
                {
                    if (Parts[1].Equals("cd")) {
                        CurrentDirectory = Parts[2].Equals("..") ? CurrentDirectory.Parent : CurrentDirectory.GetDown(Parts[2]);
                    }
                    
                }
                else
                {
                    if (Parts[0].Equals("dir"))
                    {
                        AoC_Directory dir = new AoC_Directory(CurrentDirectory, Parts[1]);
                        Dirs.Add(dir);
                        CurrentDirectory.Children.Add(dir);
                        continue;
                    }
                    CurrentDirectory.Files.Add((Parts[1], int.Parse(Parts[0])));
                }
            }

            int DataSize = Dirs.Where(d => d.GetSize() <= 100000).Select(d => d.GetSize()).Sum();
            int TotalDiskSpace = 70000000;
            int Unusued = TotalDiskSpace - Dirs.First(d => d.Name.Equals("/")).GetSize();
            int ToFree = 30000000 - Unusued;
            int DataSize2 = Dirs.Select(d => d.GetSize()).Where(d => d > ToFree).Min();
            Console.WriteLine($"Total size of directories under 100000: {DataSize}");
            Console.WriteLine($"Total size of directory, that has to be deleted (minimum but enough size): {DataSize2}");
        }

    }

    internal class AoC_Directory
    {
        public string Name { get; set; }
        public AoC_Directory Parent { get; }
        public List<AoC_Directory> Children { get; } = new();
        public List<(string name, int size)> Files { get; set; } = new();

        public AoC_Directory(AoC_Directory parent, string name)
        {
            Parent = parent; 
            Name = name;
        }

        public AoC_Directory GetDown(string name) => name.Equals("/")
            ? this
            : Children.First(x => x.Name.Equals(name));

        public int GetSize() => Children.Any()
                ? Children.Select(c => c.GetSize()).Sum() + Files.Select(f => f.size).Sum()
                : Files.Select(f => f.size).Sum();
    }
}
