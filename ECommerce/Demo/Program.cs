namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cheese = new Product(1, "Cheese", 200, "Delicious cheese", 10, DateTime.Now.AddMonths(6), true, 500);
            var biscuits = new Product(2, "Biscuits", 100, "Crunchy biscuits", 20, DateTime.Now.AddMonths(12), true, 200);
            var scratchCard = new Product(3, "Scratch Card", 50, "Lucky scratch card", 50, DateTime.Now.AddYears(1), false, 100);

            var customer = new Customer("Aya", 1000);

            var cart = new Cart();
            cart.AddItem(cheese, 2);
            cart.AddItem(biscuits, 1);
            cart.AddItem(scratchCard, 1);

            var shippingService = new ShippingService();
            var checkoutService = new CheckoutService(shippingService,30);

            checkoutService.Checkout(customer, cart);

        }
    }
}
