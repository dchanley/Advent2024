using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class Solution2
    {
        public Solution2()
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

                Console.Write(line);
                if (IsSafe(levels, 0))
                {
                    Console.WriteLine(" pass");
                    numOfSafeReports++;
                }
                else
                {
                    Console.WriteLine(" fail");
                }
            }

            Console.WriteLine($"Number of safe reports: {numOfSafeReports}");
            Console.ReadLine();
        }

        private bool IsSafe(List<int> levels, int numOfRecursions)
        {
            if (numOfRecursions == 2)
            {
                return false;
            }

            bool isIncreasing = levels[1] > levels[0];
            for (int i = 1; i < levels.Count; i++)
            {
                int diff = Math.Abs(levels[i] - levels[i - 1]);
                if (diff < 1 || diff > 3 || (levels[i] > levels[i - 1]) != isIncreasing)
                {
                    List<int> withoutCurrent = new List<int>(levels);
                    withoutCurrent.RemoveAt(i);
                    if (IsSafe(withoutCurrent, numOfRecursions + 1))
                    {
                        return true;
                    }
                    List<int> withoutPrevious = new List<int>(levels);
                    withoutPrevious.RemoveAt(i - 1);
                    if (IsSafe(withoutPrevious, numOfRecursions + 1))
                    {
                        return true;
                    }
                    return false;
                }
            }
            return true;
        }
    }
}
