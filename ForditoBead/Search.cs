using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ForditoBead
{
    class Search
    {
        private Stack stack = new Stack();
        private string helper;
        private string input;
        List<string> ruleList = new List<string>();
        private bool cont = true;
        public void ruleSearch(List<List<string>> matrix, string startingSymb)
        {
            stack.Push("#");
            stack.Push(startingSymb);
            do
            {
                helper = stack.Pop().ToString();
                for (int j = 0; j < matrix[0].Count; j++)
                {

                    if (input[0].ToString() == matrix[0][j])
                    {

                        for (int i = 0; i < matrix.Count; i++)
                        {
                            if (helper == matrix[i][0])
                            {
                                examine(matrix[i][j]);
                            }
                        }
                    }
                }
            } while (cont);
        }

        private void examine(string node)
        {

            if (node.Length == 0)
            {
                Console.WriteLine("Valami hiba történt kezdje elölről");
                cont = false;
            }

            if (node.Trim() == "elfogad")
            {
                Console.WriteLine("OK, Elemzés vége kifejezés elfogadva");
                cont = false;
            }

            if (node.Trim() == "pop")
            {
                input = input.Substring(1);
                showCurrStat("pop");

            }

            if (node.Contains('('))
            {
                string helper = node.Substring(1).Split(',')[0];
                for (int j = helper.Length - 1; j >= 0; j--)
                {
                    stack.Push(helper[j].ToString());
                }
            }

            if (node.Contains(')'))
            {
                ruleList.Add(node.Substring(0, node.Length - 1).Split(',')[1]);
                showCurrStat("");

            }

        }
        private void showCurrStat(string additional)
        {
            string stackContain = "";
            string ruleCollection = "";
            foreach (string element in stack)
            {
                if (element != "e")
                {
                    stackContain += element;
                }

            }
            foreach (string ruleNum in ruleList)
            {
                ruleCollection += ruleNum;
            }
            Console.WriteLine("({0}, {1}, {2}) {3}", input, stackContain, ruleCollection, additional);
        }

        public Search(string input)
        {
            this.input =input;
        }
    }
}
