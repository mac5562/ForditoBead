using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForditoBead
{
    class RuleHandler
    {

        private string rulePath;

        public List<List<string>> loadRules()
        {
            List<List<string>> matrix = new List<List<string>>();
            List<string> row = new List<string>();
            string[] rawData = new string[7];
            StreamReader sr = new StreamReader(rulePath);
            string helper = "";
            int index = 0;
            while (!sr.EndOfStream)
            {
                helper += sr.ReadLine();
                for (int i = 0; i < rawData.Length; i++)
                {
                    rawData[i] = helper.Split('_')[i];
                }
                row = new List<string>();
                for (int j = 0; j < rawData.Length; j++)
                {
                    row.Add(rawData[j]);

                }
                matrix.Add(row);
                helper = "";
                index++;
            }
            return matrix;
        }

        public void showRules(List<List<string>> matrix)
        {
            Console.WriteLine("Beolvasott szabályrendszer: ");
            Console.WriteLine("");
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    if (matrix[i][j] != null)
                    {
                        Console.Write(string.Format("\t" + matrix[i][j] + "\t" + "|"));
                    }
                }
                Console.WriteLine();
            }
        }
        public RuleHandler(string path)
        {
            this.rulePath = path;
        }




    }
}

