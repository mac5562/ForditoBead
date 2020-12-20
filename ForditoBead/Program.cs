using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForditoBead
{
    class Program
    {
        static void Main(string[] args)
        {
            string enviroment = Environment.CurrentDirectory;
            RuleHandler ruleHandler = new RuleHandler(Directory.GetParent(enviroment).Parent.FullName+"/Szabaly.txt");

           
            InputCheck inputCheck = new InputCheck();
           
            List<List<string>> rules = ruleHandler.loadRules();
            ruleHandler.showRules(rules);


            Search search = new Search((inputCheck.inputLoad()));
            search.ruleSearch(rules, "E");


            Console.ReadLine();
        }
    }
}
