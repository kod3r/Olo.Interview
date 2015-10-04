using System;
using Olo.Interview;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;

namespace TopPizzas.Tests
{
    [TestClass]
    public class TopPizzasTests
    {
        [TestMethod]
        public void PizzasWithSameToppingsShouldHaveSameConfigurationId()
        {
            string[] toppings = new string[] { "feta cheese", "sausage" };
            Pizza pizza1 = new Pizza();
            Pizza pizza2 = new Pizza();
            pizza1.Toppings = toppings;
            pizza2.Toppings = toppings;
            Assert.AreEqual(pizza1.ConfigurationId, pizza2.ConfigurationId, "ConfigurationIds did not match");
        }

        [TestMethod]
        public void PizzasWithDifferentToppingsShouldHaveDifferentConfigurationId()
        {
            Pizza pizza1 = new Pizza();
            Pizza pizza2 = new Pizza();
            pizza1.Toppings = new string[] { "feta cheese", "sausage" };
            pizza2.Toppings = new string[] { "beef", "pepperoni" };
            Assert.AreNotEqual(pizza1.ConfigurationId, pizza2.ConfigurationId, "ConfigurationIds should not be equal");
        }

        [TestMethod]
        public void PizzaAnalystTest()
        {
            List<PizzaConfigurationInfo> topPizzaConfigurations = PizzaAnalyst.GetTopConfigurations(2, new FileInfo(".\\test.json"));
            Assert.AreEqual("pepperoni", topPizzaConfigurations[0].Toppings[0]);
            Assert.AreEqual("feta cheese", topPizzaConfigurations[1].Toppings[0]);
        }

        [TestMethod]
        public void PizzaAnalystCanConsumeJsonApiTest()
        {
            List<PizzaConfigurationInfo> top20 = PizzaAnalyst.GetTop20("http://files.olo.com/pizzas.json");
            Assert.AreEqual(20, top20.Count);
            int num = 0;
            foreach (PizzaConfigurationInfo pizzaInfo in top20)
            {
                Console.WriteLine("{0}. {1} ({2})", ++num, string.Join(", ", pizzaInfo.Toppings), pizzaInfo.Count);
            }
        }
    }
}
