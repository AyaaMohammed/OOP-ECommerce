using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public void AddItem(Product product, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }
            var existingItem = items.FirstOrDefault(item => item.Product.ProductId == product.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                items.Add(new CartItem(product, quantity));
            }
        }
        public List<CartItem> GetItems() {
            return items;
        }
        public double GetTotalPrice()
        {
            return (double)items.Sum(item => item.TotalPrice);
        }
        public bool IsEmpty()
        {
            return !items.Any();
        }
        public List<CartItem> GetShippableItems()
        {
            return items.Where(item => item.Product.CanShipping).ToList();
        }
        public void Clear()
        {
            items.Clear();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Cart Items:");
            foreach (var item in items)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine($"Total Price: {GetTotalPrice():C}");
            return sb.ToString();
        }

    }
}
