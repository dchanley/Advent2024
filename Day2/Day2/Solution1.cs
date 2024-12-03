using System;
using System.Collections.Generic;
using System.IO;

namespace Day2
{
    internal class Solution1
    {
        public Solution1()
        {
            solution();
        }

        private void solution()
        {
            string[] lines = File.ReadAllLines("Input.txt");
            int numOfSafeReports = 0;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(' ');
                List<int> levels = new List<int>();
                foreach (string part in parts)
                {
                    if (int.TryParse(part, out int level))
                        levels.Add(level);
                }

                if (IsSafe(levels))
                {
                    numOfSafeReports++;
                }

            }

            Console.WriteLine($"Number of safe reports: {numOfSafeReports}");
            Console.ReadLine();
        }

        private bool IsSafe(List<int> levels)
        {            
            bool isIncreasing = levels[1] > levels[0];
            for (int i = 1; i < levels.Count; i++)
            {
                int diff = Math.Abs(levels[i] - levels[i - 1]);
                if (diff < 1 || diff > 3)
                {
                    return false;
                }
                    

                if ((levels[i] > levels[i - 1]) != isIncreasing)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
