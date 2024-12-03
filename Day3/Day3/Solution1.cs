using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day3
{
    internal class Solution1
    {
        public Solution1() {
            solution();
        }
        public void solution()
        {
            string[] lines = File.ReadAllLines("Input.txt");
            Regex pattern = new Regex("mul\\(\\d+,\\d+\\)");
            List<int> results = new List<int>();
            foreach (string line in lines)
            {                
                MatchCollection matches = pattern.Matches(line);
                foreach (Match match in matches)
                {
                    string[] temp =match.ToString().Trim().Replace("mul", "").Replace("(", "").Replace(")", "").Split(',');
                    results.Add(Convert.ToInt32(temp[0])* Convert.ToInt32(temp[1]));                    
                }                
            }
            int solution = 0;
            foreach(int i in results)
            {
                solution += i;
            }
            Console.WriteLine(solution);
            Console.Read();
        }
    }
}
