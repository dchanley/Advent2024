using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class Solution1
    {
        public Solution1() {
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
                rightNum.Add(Convert.ToInt32(temp[temp.Length-1]));
            }
            leftNum.Sort();
            rightNum.Sort();

            int solution = 0;
            int i = 0;
            while (i < rightNum.Count)
            {
                if (leftNum[i] < rightNum[i])
                {
                    solution += rightNum[i] - leftNum[i];
                }
                else
                {
                    solution += leftNum[i] - rightNum[i];
                }
                i++;
            }
            Console.WriteLine(solution);
            Console.ReadLine();
        }
    }
}
