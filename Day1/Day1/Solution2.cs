using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class Solution2
    {
        public Solution2()
        {
            solution();
        }
        private void solution()
        {
            StreamReader reader = new StreamReader("InputPart1.txt");
            List<string> lines = new List<string>();
            List<int> leftNum = new List<int>();
            List<int> rightNum = new List<int>();
            while (!reader.EndOfStream)
            {
                lines.Add(reader.ReadLine());
            }
            reader.Close();
            foreach (string line in lines)
            {
                string[] temp = line.Split(' ');
                leftNum.Add(Convert.ToInt32(temp[0]));
                rightNum.Add(Convert.ToInt32(temp[temp.Length - 1]));
            }
            leftNum.Sort();
            rightNum.Sort();
            int solution = 0;
            foreach (int lNum in leftNum)
            {
                int multiply = 0;
                foreach (int rNum in rightNum)
                {
                    if (rNum == lNum)
                    {
                        multiply++;
                    }
                }
                solution += lNum * multiply;
            }
            Console.WriteLine(solution);
            Console.ReadLine();
        }
    }
}
