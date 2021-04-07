using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFT.API.Entity
{
    public class OrderItem
    {
        public enum MorningOrderItems
        {
            eggs = 1,
            toast = 2,
            coffee = 3
        }

        public enum NightOrderItems
        {
            steak = 1,
            potato = 2,
            wine = 3,
            cake = 4
        }
        public List<int> OrderItemsList { get; private set; }

        private readonly List<string> itemsAllowedMoreThanOne = new List<string>() 
        { 
            MorningOrderItems.coffee.ToString(), 
            NightOrderItems.potato.ToString() 
        };

        public OrderItem(IEnumerable<string> orderItems)
        {
            OrderItemsList = new List<int>();
            foreach (var orderItem in orderItems)
            {
                int itemNumber;

                if (!Int32.TryParse(orderItem, out itemNumber))
                    throw new InvalidOperationException($"The order item: \"{orderItem}\" is invalid");

                this.OrderItemsList.Add(itemNumber);
            }
        }

        public string GetDescription<T>(int itemNumber, int combo) where T : Enum
        {
            if (!Enum.IsDefined(typeof(T), itemNumber))
                throw new InvalidOperationException("error");

            string orderItemDescription = Enum.GetName(typeof(T), itemNumber);

            if (combo > 1 && !itemsAllowedMoreThanOne.Contains(orderItemDescription))
                throw new InvalidOperationException("error");

            string concatCombo = (combo > 1 ? $"(x{combo})" : string.Empty);
            return orderItemDescription + concatCombo;
        }
    }
}
