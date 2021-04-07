using System;
using System.Collections.Generic;
using System.Linq;
using static GFT.API.Entity.OrderItem;

namespace GFT.API.Entity
{
    public class Order
    {
        private readonly Dish dish;
        private readonly OrderItem orderItems;

        public Order(string orderInput)
        {
            string[] arr = orderInput.Split(",");

            dish = new Dish(arr[0]);
            orderItems = new OrderItem(arr.Skip(1));
        }

        public override string ToString()
        {
            List<string> outputOrderItems = new List<string>();

            IEnumerable<int> distinctedList = orderItems.OrderItemsList.OrderBy(i => i).Distinct();
            foreach (var itemNuber in distinctedList)
            {
                int combo = orderItems.OrderItemsList.Count(i => i == itemNuber);
                
                try
                {
                    switch (dish.Daytime)
                    {
                        case "morning":
                            outputOrderItems.Add(orderItems.GetDescription<MorningOrderItems>(itemNuber, combo));
                            break;

                        default: 
                            outputOrderItems.Add(orderItems.GetDescription<NightOrderItems>(itemNuber, combo));
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    outputOrderItems.Add(ex.Message);
                    break;
                }
            }

            return string.Join(", ", outputOrderItems);
        }
    }
}
