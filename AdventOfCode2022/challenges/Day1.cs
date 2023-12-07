using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.challenges
{
    public class Day1
    {
        public void Run()
        {
            string? filePath = @"C:\Users\KM\source\repos\AdventOfCode2022\inputs\day1Input.txt";

            ProcessFile(filePath);



            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        void ProcessFile(string filePath)
        {
            var lines = new List<string>();

            var cardPoints = 0;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            var elfCallories = new List<int>();

            var maxCallories = 0;
            var currentCallories = 0;
            for(var i = 0; i < lines.Count; i++)
            {
                if(i == lines.Count - 1 || string.IsNullOrEmpty(lines[i]))
                {
                    maxCallories = currentCallories > maxCallories ? currentCallories : maxCallories;
                    elfCallories.Add(currentCallories);
                    currentCallories = 0;
                }
                else
                    currentCallories += int.Parse(lines[i]);
            }

            var top3TotalCallories = elfCallories.OrderByDescending(x => x).Take(3).Sum();

            Console.WriteLine($"max callories: {maxCallories}");
            Console.WriteLine($"top 3 total callories: {top3TotalCallories}");
        }
    }
}
