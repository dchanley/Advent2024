using System;
using System.Collections.Generic;
using System.IO;

namespace Day4
{
    internal class Solution1
    {
        public Solution1()
        {
            solution();
        }

        public void solution()
        {
            List<string> list = new List<string>();
            StreamReader sr = new StreamReader("Input.txt");
            while (!sr.EndOfStream)
            {
                list.Add(sr.ReadLine().ToUpper()); 
            }
            sr.Close();

            int answer = 0;
            answer += forward(list);
            answer += backward(list);
            answer += upward(list);
            answer += downward(list);
            answer += leftUpward(list);
            answer += rightUpward(list);
            answer += leftDownward(list);
            answer += rightDownward(list);

            Console.WriteLine(answer);
            Console.ReadLine();
        }

        public int forward(List<string> list)
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j <= list[i].Length - 4; j++) 
                {
                    if (list[i][j] == 'X' && list[i][j + 1] == 'M' && list[i][j + 2] == 'A' && list[i][j + 3] == 'S')
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public int backward(List<string> list)
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 3; j < list[i].Length; j++) 
                {
                    if (list[i][j] == 'X' && list[i][j - 1] == 'M' && list[i][j - 2] == 'A' && list[i][j - 3] == 'S')
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public int upward(List<string> list)
        {
            int count = 0;
            for (int i = 3; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Length; j++)
                {
                    if (list[i][j] == 'X' && list[i - 1][j] == 'M' && list[i - 2][j] == 'A' && list[i - 3][j] == 'S')
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public int downward(List<string> list)
        {
            int count = 0;
            for (int i = 0; i <= list.Count - 4; i++)
            {
                for (int j = 0; j < list[i].Length; j++)
                {
                    if (list[i][j] == 'X' && list[i + 1][j] == 'M' && list[i + 2][j] == 'A' && list[i + 3][j] == 'S')
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public int leftUpward(List<string> list)
        {
            int count = 0;
            for (int i = 3; i < list.Count; i++) 
            {
                for (int j = 3; j < list[i].Length; j++) 
                {
                    if (list[i][j] == 'X' && list[i - 1][j - 1] == 'M' && list[i - 2][j - 2] == 'A' && list[i - 3][j - 3] == 'S')
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public int rightUpward(List<string> list)
        {
            int count = 0;
            for (int i = 3; i < list.Count; i++) 
            {
                for (int j = 0; j <= list[i].Length - 4; j++) 
                {
                    if (list[i][j] == 'X' && list[i - 1][j + 1] == 'M' && list[i - 2][j + 2] == 'A' && list[i - 3][j + 3] == 'S')
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public int leftDownward(List<string> list)
        {
            int count = 0;
            for (int i = 0; i <= list.Count - 4; i++) 
            {
                for (int j = 3; j < list[i].Length; j++) 
                {
                    if (list[i][j] == 'X' && list[i + 1][j - 1] == 'M' && list[i + 2][j - 2] == 'A' && list[i + 3][j - 3] == 'S')
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public int rightDownward(List<string> list)
        {
            int count = 0;
            for (int i = 0; i <= list.Count - 4; i++) 
            {
                for (int j = 0; j <= list[i].Length - 4; j++) 
                {
                    if (list[i][j] == 'X' && list[i + 1][j + 1] == 'M' && list[i + 2][j + 2] == 'A' && list[i + 3][j + 3] == 'S')
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
