using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFT.API.Entity
{
    public class Dish
    {
        private readonly IEnumerable<string> availableDishes = new List<string>() { "morning", "night" };

        public string Daytime { get; private set; }

        public Dish(string daytime)
        {
            this.Daytime = daytime.ToLower();

            if (!availableDishes.Contains(this.Daytime))
                throw new InvalidOperationException($"The daytime: \"{this.Daytime}\" is invalid.");
        }
    }
}
