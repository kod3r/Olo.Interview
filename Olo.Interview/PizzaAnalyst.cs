using Bam.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Olo.Interview
{
    public class PizzaAnalyst
    {
        public static List<PizzaConfigurationInfo> GetTop20(string dataSource)
        {
            if (dataSource.StartsWith("http", StringComparison.InvariantCultureIgnoreCase))
            {
                return GetTopConfigurations(20, new Uri(dataSource));
            }
            else
            {
                return GetTopConfigurations(20, new FileInfo(dataSource));
            }
        }
        public static List<PizzaConfigurationInfo> GetTopConfigurations(int count, Uri uri)
        {
            WebClient client = new WebClient();
            return GetTopConfigurations(count, client.DownloadString(uri));
        }
        public static List<PizzaConfigurationInfo> GetTopConfigurations(int count, FileInfo file)
        {
            return GetTopConfigurations(count, File.ReadAllText(file.FullName));
        }
        public static List<PizzaConfigurationInfo> GetTopConfigurations(int count, string json)
        {
            return GetTopConfigurations(count, json.FromJson<List<Pizza>>());
        }
        public static List<PizzaConfigurationInfo> GetTopConfigurations(int count, List<Pizza> pizzas)
        {
            Dictionary<string, PizzaConfigurationInfo> keyedResults = new Dictionary<string, PizzaConfigurationInfo>();
            foreach (Pizza pizza in pizzas)
            {
                if (keyedResults.ContainsKey(pizza.ConfigurationId))
                {
                    keyedResults[pizza.ConfigurationId].Count += 1;
                }
                else
                {
                    PizzaConfigurationInfo info = new PizzaConfigurationInfo(pizza.ConfigurationId, pizza.Toppings);
                    keyedResults.Add(pizza.ConfigurationId, info);
                }       
            }
            List<PizzaConfigurationInfo> results = keyedResults.Values.ToList();
            results.Sort((p1, p2) => p2.Count.CompareTo(p1.Count));
            return results.Take(count).ToList();
        }
    }
}
