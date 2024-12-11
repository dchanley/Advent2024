using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    internal class Solution1
    {
        public Solution1() {
            solution();
        }
        private void solution()
        {
            List<orderedPair> orderedPairs = new List<orderedPair>();
            List<string> changes = new List<string>();
            StreamReader streamReader = new StreamReader("Input.txt");
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                while (!String.IsNullOrEmpty(line))
                {
                    string[] temp = line.Split('|');
                    orderedPairs.Add(new orderedPair( Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1])));
                    line = streamReader.ReadLine();
                }
                while (!streamReader.EndOfStream)
                {
                    line = streamReader.ReadLine();
                    changes.Add(line);
                }

            }
            streamReader.Close();            
            List<string> trueInstructions = new List<string>();
            foreach (string line in changes)
            {
                string[] temp = line.Split(',');
                bool valid = true;
                int i = 1;
                List<orderedPair> pair = new List<orderedPair>(orderedPairs);                
                foreach (string key in temp)
                {
                    int holder = Convert.ToInt32(key);
                    if (i < temp.Length)
                    {
                        int compare = Convert.ToInt32(temp[i]);
                        int result = pair.Where(x => x.left == compare &&  x.right == holder).Count();
                        if (result > 0)
                        {
                            valid = false;
                        }
                        else
                        {
                            var remove = pair.Where(x => x.right == compare && x.left == holder);
                            pair.Remove(remove.ElementAt(0));
                        }
                    }
                    i++;
                }
                if (valid)
                {
                    trueInstructions.Add(line);
                }                
            }
            if (trueInstructions.Count > 0)
            {
                int solution = 0;
                foreach (string line in trueInstructions)
                {
                    string[] holder = line.Split(',');                    
                    string mid = holder[holder.Length / 2];
                    solution += Convert.ToInt32(mid);
                }
                Console.WriteLine(solution);
                Console.ReadLine();
            }
            
        }
    }
    class orderedPair
    {

        public orderedPair(int left, int right)
        {
            this.left = left;
            this.right = right;
        }
        public int left {  get; set; }
        public int right { get; set; }
    }
}
