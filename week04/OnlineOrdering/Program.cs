// W04 Foundation #2 - Online Ordering Program
// Name: Yang Liao
// Date: 2025-09-26

using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // Addresses
        Address addrUsa = new Address("123 Main St", "Ontario", "CA", "USA");
        Address addrIntl = new Address("55 King St W", "Toronto", "ON", "Canada");

        // Customers
        Customer alice = new Customer("Alice Johnson", addrUsa);
        Customer bob   = new Customer("Bob Lee", addrIntl);

        // Order 1 (USA -> $5 shipping)
        Order order1 = new Order(alice);
        order1.AddProduct(new Product("USB-C Cable",   "P1001", 7.99m, 3));
        order1.AddProduct(new Product("Wireless Mouse","P2002", 19.50m, 1));

        // Order 2 (International -> $35 shipping)
        Order order2 = new Order(bob);
        order2.AddProduct(new Product("Mechanical Keyboard", "P3003", 89.00m, 1));
        order2.AddProduct(new Product("HDMI Adapter",        "P4004", 12.75m, 2));
        order2.AddProduct(new Product("Laptop Stand",        "P5005", 29.99m, 1));

        // Display
        PrintOrder(order1);
        Console.WriteLine(new string('-', 40));
        PrintOrder(order2);
    }

    static void PrintOrder(Order order)
    {
        Console.WriteLine("PACKING LABEL");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine();

        Console.WriteLine("SHIPPING LABEL");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();

        var usd = CultureInfo.GetCultureInfo("en-US");
        Console.WriteLine($"Total: {order.GetTotalPrice().ToString("C", usd)}");
    }
}
