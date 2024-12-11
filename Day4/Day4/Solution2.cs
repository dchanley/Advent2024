using System;
using System.Collections.Generic;
using System.IO;

namespace Day4
{
    internal class Solution2
    {
        public Solution2()
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
            traverseTheList(list);
        }

        public void traverseTheList(List<string> list)
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Length; j++)
                {
                    if (list[i][j] == 'A')
                    {
                        if (check(list, i, j))
                        {
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine($"Total X-MAS patterns: {count}");
            Console.ReadLine();
        }

        public bool check(List<string> list,int i, int j)
        {            
            bool arm1 = false;
            bool arm2 = false;
            try
            {
                if (list[i-1][j-1] == 'M')
                {
                    if (list[i + 1][j + 1] == 'S')
                    {
                        arm1 = true;
                    }
                }
                else if (list[i - 1][j - 1] == 'S')
                {
                    if (list[i + 1][j + 1] == 'M')
                    {
                        arm1 = true;
                    }
                }
                if (list[i - 1][j + 1] == 'M')
                {
                    if (list[i + 1][j - 1] == 'S')
                    {
                        arm2 = true;
                    }
                }
                else if (list[i - 1][j + 1] == 'S')
                {
                    if (list[i + 1][j - 1] == 'M')
                    {
                        arm2 = true;
                    }
                }
            }
            catch
            {
                arm1 = false;
                arm2 = false;
            }
            if (arm1 && arm2)
            {
                return true;
            }
            return false;
        }
    }
}
