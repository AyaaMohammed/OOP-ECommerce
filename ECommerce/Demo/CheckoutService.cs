using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class CheckoutService
    {
        ShippingService _shippingService;
        double ShippingFee = 30;

        public CheckoutService(ShippingService shippingService,double _shippingFee)
        {
            _shippingService = shippingService;
            ShippingFee = _shippingFee;
        }

        public void Checkout(Customer customer, Cart cart)
        {
            // Check Cart is not empty
            if (cart.IsEmpty())
                throw new Exception("Cart is empty.");

            // Check expiration date of products & reduce stock
            foreach (var item in cart.GetItems())
            {
                if (item.Product.ExpirationDate < DateTime.Now)
                    throw new Exception($"{item.Product.Name} is expired.");

                item.Product.ReduceStock(item.Quantity);
            }
            // Calculate total price and shipping fee
            double subtotal = cart.GetTotalPrice();
            double shipping = cart.GetShippableItems().Any() ? ShippingFee : 0;
            double totalAmount = subtotal + shipping;
            // Check customer balance
            if (customer.Balance < totalAmount)
                throw new Exception("Insufficient balance.");
            customer.Balance -= totalAmount;
            // ship items to display shipping information
            var shippableItems = cart.GetShippableItems()
                .Select(item => new ShippableItem($"{item.Quantity}x {item.Product.Name}", item.Product.Weight * item.Quantity))
                .Cast<IShippable>()
                .ToList();

            if (shippableItems.Any())
                _shippingService.ShipItems(shippableItems);
            // checkout receipt
            Console.WriteLine("** Checkout receipt **");
            foreach (var item in cart.GetItems())
            {
                Console.WriteLine($"{item.Quantity}x {item.Product.Name}    {item.TotalPrice}");
            }
            Console.WriteLine("----------------------");
            Console.WriteLine($"Subtotal     {subtotal}");
            Console.WriteLine($"Shipping     {shipping}");
            Console.WriteLine($"Amount       {totalAmount}\n");
        }
    }
}
