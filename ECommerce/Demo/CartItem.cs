using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class CartItem
    {
        private int quantity;
        public Product Product { get; set; }
        public int Quantity
        {
            get => quantity;
            set
            {
                if (value > Product.Quantity)
                {
                    throw new ArgumentException("Quantity cannot exceed available stock.");
                }
                quantity = value;
            }
        }
        public decimal TotalPrice => Product.Price * Quantity;
        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public override string ToString()
        {
            return $"{Product.Name} - {Quantity} x {Product.Price:C} = {TotalPrice:C}";
        }

    }
}
