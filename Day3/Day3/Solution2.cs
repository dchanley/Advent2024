using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day3
{
    internal class Solution2
    {
        public Solution2()
        {
            solution();
        }
        public void solution()
        {
            string filePath = "Input.txt";
            string[] lines = File.ReadAllLines(filePath);
            Regex instructionPattern = new Regex(@"mul\((\d+),(\d+)\)|do\(\)|don't\(\)");
            bool isEnabled = true;
            int solution = 0;
            foreach (string line in lines)
            {
                MatchCollection matches = instructionPattern.Matches(line);

                foreach (Match match in matches)
                {
                    if (match.Value.StartsWith("mul"))
                    {
                        if (isEnabled)
                        {
                            int num1 = int.Parse(match.Groups[1].Value);
                            int num2 = int.Parse(match.Groups[2].Value);
                            solution += num1 * num2;
                        }
                    }
                    else if (match.Value == "do()")
                    {
                        isEnabled = true;
                    }
                    else if (match.Value == "don't()")
                    {
                        isEnabled = false;
                    }
                }
            }
            Console.WriteLine(solution);
            Console.Read();
        }
    }
}
