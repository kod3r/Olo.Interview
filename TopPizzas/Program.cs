using Bam.Net.Testing;
using Olo.Interview;
using System;
using System.Collections.Generic;

namespace TopPizzas
{
    [Serializable]
    class Program : CommandLineTestInterface
    {
        static string sourceArgName = "dataSrc";

        static void Main(string[] args)
        {
            AddValidArgument(sourceArgName, false);
            DefaultMethod = typeof(Program).GetMethod("Start");

            Initialize(args); // parses command line arguments
        }

        #region do not modify
        public static void Start()
        {
            
            string sourcePath = ".\\pizzas.json";
            if (Arguments.Contains(sourceArgName))
            {
                sourcePath = Arguments[sourceArgName];
            }

            // write an application (in C#, F# or JS) to output the top 20 most frequently
            // ordered pizza configurations, listing the toppings for each along with the 
            // number of times that pizza configuration has been ordered
            List<PizzaConfigurationInfo> top20 = PizzaAnalyst.GetTop20(sourcePath);
            int num = 0;
            foreach (PizzaConfigurationInfo pizzaInfo in top20)
            {
                Console.WriteLine("{0}. {1} ({2})", ++num, string.Join(", ", pizzaInfo.Toppings), pizzaInfo.Count);
            }

            Pause("Press enter to exit");
        }
        #endregion
    }
}
