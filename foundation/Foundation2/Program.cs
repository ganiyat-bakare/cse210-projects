using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Maple St", "Toronto", "ON", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Laurel Brown", address2);

        // Create orders for each customer
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", 101, 999.99m, 1));
        order1.AddProduct(new Product("Mouse", 102, 25.50m, 2));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Phone", 201, 499.99m, 1));
        order2.AddProduct(new Product("Headphones", 202, 89.99m, 1));

        // Display information for Order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():0.00}");
        Console.WriteLine(); // For better readability

        // Display information for Order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():0.00}");
    }
}