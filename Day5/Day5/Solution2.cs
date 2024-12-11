using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    internal class Solution2
    {
        public Solution2()
        {
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
                    orderedPairs.Add(new orderedPair(Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1])));
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
                        int result = pair.Where(x => x.left == compare && x.right == holder).Count();
                        if (result > 0)
                        {
                            valid = false;
                        }
                    }
                    i++;
                }
                if (!valid)
                {
                    trueInstructions.Add(line);
                }
            }
            if (trueInstructions.Count > 0)
            {
                int iCounter = 0;
                while (iCounter < trueInstructions.Count)
                {
                    trueInstructions[iCounter] = fixInstructions(trueInstructions[iCounter], orderedPairs);
                    iCounter++;
                }
                
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
        private string fixInstructions(string line, List<orderedPair> pair)
        {
            string[] temp = line.Split(',');
            int counter = 0;
            int i = 1;
            while(counter < temp.Length)
            {
                string key = temp[counter];
                int holder = Convert.ToInt32(key);
                if (i < temp.Length)
                {
                    int compare = Convert.ToInt32(temp[i]);
                    int result = pair.Where(x => x.left == compare && x.right == holder).Count();
                    if (result > 0)
                    {
                        string tempHolder = holder.ToString();
                        temp[counter] = temp[i];
                        temp[i] = tempHolder;
                        i = 1;
                        counter = 0;
                    }
                    else
                    {
                        i++;
                        counter++;
                    }
                }
                else
                {
                    counter++;
                }               
            }
            string returnString = "";
            foreach (string key in temp)
            {
                returnString += key + ",";
            }
            returnString = returnString.Trim(',');
            return returnString;
        }

    }    
}
