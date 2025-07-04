using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool CanShipping { get; set; }

        public double Weight { get; set; }
        public Product(int _id,string _name,decimal _price , string _description ,int _quantity , DateTime _expirationDate,bool _canShipping , double _weight)
        {
            ProductId = _id;
            Name = _name;
            Price = _price;
            Description = _description;
            Quantity = _quantity;
            ExpirationDate = _expirationDate;
            CanShipping = _canShipping;
            Weight = _weight;
        }
        public void ReduceStock(int quantity)
        {
            if (quantity > Quantity)
            {
                throw new ArgumentException("Insufficient stock available.");
            }
            Quantity -= quantity;
        }
        override public string ToString()
        {
            return $"{Name} - Price: {Price:C} - Quantity: {Quantity} - Expiration Date: {ExpirationDate.ToShortDateString()} - Can Shipping: {CanShipping} - Weight: {Weight}kg";
        }
    }
}
