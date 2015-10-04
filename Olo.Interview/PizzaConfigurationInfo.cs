
namespace Olo.Interview
{
    /// <summary>
    /// Represents information about a pizza configuration
    /// </summary>
    public class PizzaConfigurationInfo
    {
        public PizzaConfigurationInfo(string configurationId, string[] toppings)
        {
            ConfigurationId = configurationId;
            Toppings = toppings;
            Count = 1;
        }
        public string ConfigurationId { get; set; }
        public int Count { get; set; }
        public string[] Toppings { get; set; }
    }
}
