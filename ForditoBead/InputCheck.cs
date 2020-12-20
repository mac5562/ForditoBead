using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ForditoBead
{
    class InputCheck
    {
        private bool inputCheck=true;
        string enviroment = Environment.CurrentDirectory;
        public string inputLoad()
        {
            string input = "";
            while (inputCheck == true)
            {
                //Console.WriteLine(Directory.GetParent(enviroment).Parent.FullName);
                Console.Write("Kérjük adja meg az inputot: ");
                input = Console.ReadLine();
                input = Check(input);
                if (input == "wrong")
                {
                    Console.WriteLine("Megadott kifejezés rossz, próbálja meg újra");
                    
                }
                else
                {
                    inputCheck = false;
                }
            }
            return input;
        }
        public string Check(string input)
        {
            string modified = "";
            modified = Regex.Replace(input, "([0-9]{1,2})+", "i");
            if (input==String.Empty)
            {
                return "wrong";
            }
            
            if (input.Contains('('))
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i]=='(')
                    {
                       input=input.Substring(i+1,input.Length-1);
                        modified = input;
                    }
                   
                }
            }
            if (input.Contains(')'))
            {
                for (int i = 0; i < input.Length; i++)
                {
                     if (input[i] == ')')
                    {
                        input = input.Remove(i,1);
                        modified = input;
                    }
                }
                
            }
            if (input[input.Length - 1] != '#')
            {
                modified += '#';
            }
            if (modified.Contains("i")&&modified.Contains("*") && !modified.Contains("(") &&!modified.Contains(")") && modified.Contains("#") && modified.Contains("+"))
            {
                return modified;
            }


            return "wrong";
        }
        public InputCheck()
        {

        }
    }
}
