using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class ShippingService
    {
        public void ShipItems(IEnumerable<IShippable> items)
        {
            Console.WriteLine("\nShipping Items...");
            double totalWeight = 0;

            foreach (var item in items)
            {
                Console.WriteLine($"Item: {item.GetName()}, Weight: {item.GetWeight()} grams");
                totalWeight += item.GetWeight();
            }

            Console.WriteLine($"Total weight: {totalWeight / 1000} kg\n");
        }
    }
}
