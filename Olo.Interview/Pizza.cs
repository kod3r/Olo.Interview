using Bam.Net;
using System.Collections.Generic;

namespace Olo.Interview
{
    /// <summary>
    /// Represents a Pizza
    /// </summary>
    public class Pizza
    {
        List<string> _sortedToppings;
        public Pizza()
        {
            _sortedToppings = new List<string>();
        }

        string _configurationId;
        /// <summary>
        /// The md5 hash of the current pizzas toppings acting as a 
        /// unique identifier for the configuration of this pizza
        /// </summary>
        public string ConfigurationId
        {
            get
            {
                return string.Join(", ", _sortedToppings.ToArray()).Md5();
            }
        }

        /// <summary>
        /// The toppings on the current pizza
        /// </summary>
        public string[] Toppings
        {
            get
            {
                return _sortedToppings.ToArray();
            }
            set
            {
                _sortedToppings = new List<string>(value);
                _sortedToppings.Sort();
            }
        }
    }
}
